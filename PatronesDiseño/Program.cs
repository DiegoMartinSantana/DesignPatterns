using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using PatronesDiseño.Factory_Method;
using PatronesDiseño.models;
using PatronesDiseño.RepositoryPattern;
using PatronesDiseño.Singleton;
using PatronesDiseño.Strategy;
using PatronesDiseño.UnitofWork;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace PatronesDiseño
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region SINGLETON
            var singleton = Singleton.Singleton.Instance;

            var log = Singleton.Log.Instance;
            log.Save("Hola Mundo");
            Console.WriteLine("Hello, World!");
            #endregion

            
            #region FACTORY METHOD
            //CREO LAS FABRICAS CONCRETAS

            var WebFactory = new WebSaleFactory(0.15); //discount 15%
            var PhoneFactory = new PhoneSaleFactory(0.30);  //recargo del 30%
            var CatalogFactory = new CatalogSaleFactory(199); // venta realizada x catalogo 199
            var PhysicalFactory = new PhysicalSaleFactory(0.10, 0.5); //recargo del 10% y descuento del 5%

            //asigno al tipo ISALE  
            ISale saleWeb = WebFactory.Vender(); // crea una venta por web
            saleWeb.Vender(1000); // le paso el monto de la venta vendida

            ISale salePhone = PhoneFactory.Vender();
            salePhone.Vender(500);

            ISale saleCatalog = CatalogFactory.Vender();
            saleCatalog.Vender(300);

            ISale salePhysical = PhysicalFactory.Vender();
            salePhysical.Vender(500000);
            #endregion

            #region ENTITY

            //USO DE IMEDICO REPOSITORY
            using(var context = new DiagnosticoContext())
            {
                var medicoRepository = new MedicoRepository(context);

                var listadoMedicos = medicoRepository.GetAll();
                foreach (var medico in listadoMedicos)
                {
                    Console.WriteLine(medico.Nombre);
                }
            }   


            using (var context = new DiagnosticoContext())
            {

                var listadoMedicos = context.Medicos.ToList();
                foreach (var medico in listadoMedicos)
                {
                    Console.WriteLine(medico.Nombre);
                }
                //INNER JOIN 
                var listadoMedicosOrdenada = (from m in context.Medicos
                                              join t in context.Turnos on m.Idmedico equals t.Idmedico
                                              join e in context.Especialidades on m.Idespecialidad equals e.Idespecialidad
                                              join p in context.Pacientes on t.Idpaciente equals p.Idpaciente
                                              orderby m.Nombre
                                              select new
                                              {
                                                  MedicoNombre = m.Nombre,
                                                  TurnoFecha = t.Fechahora,
                                                  EspecialidadMedico = e.Nombre,
                                                  PacienteAtendido = p.Nombre
                                              });

                foreach (var item in listadoMedicosOrdenada)
                {
                    Console.WriteLine(item.MedicoNombre);
                    Console.WriteLine(item.TurnoFecha);
                    Console.WriteLine(item.EspecialidadMedico);

                    Console.WriteLine(item.PacienteAtendido);
                }


                //LEFT JOIN 

                //pacietnes sin turnos asociados y con tambien
                var LeftJoin = (from p in context.Pacientes
                                join t in context.Turnos on p.Idpaciente equals t.Idpaciente into pacientesCONYSINTURNOS
                                from turnocontenido in pacientesCONYSINTURNOS.DefaultIfEmpty() ///DONDE LOS TURNOS EN ESO SEAN NULOS
                                orderby p.Nombre
                                select new
                                {
                                    IdPaciente =p.Idpaciente,
                                    Paciente = p.Nombre,
                                    Turno = turnocontenido == null ? "No posee turno" : turnocontenido.Fechahora.ToString()
                                }
                                );
              

                Console.WriteLine("PACIENTES CON Y SIN TURNOS*********************************");
                foreach(var item in LeftJoin)
                {
                    Console.WriteLine(item.Paciente);
                    Console.WriteLine(item.Turno);
                }
                //RIGTH JOIN 
                //CAMBIO ORDEN TABLAS 


            };
            #endregion

            #region ENTITY WITH REPOSITORY

            /*    using (var context = new DiagnosticoContext())
                 {
                     var Repository_ObrasSo = new Repository<ObrasSociale>(context); //uso de forma generica el repositorty para este modelo
                     var Repository_Especialidades = new Repository<Especialidade>(context); //uso para esta otra entidad el  mismo repository

                     var espe = new Especialidade();
                     espe.Idespecialidad = 15416526;
                     espe.Nombre = "deigo esdadadadada";
                     Repository_Especialidades.Add(espe);
                     Repository_Especialidades.Save();

                 };
            */
            #endregion

            #region UnitOfWork
            /*  using (var context = new DiagnosticoContext())
              {
                  //UNIT OF WORK ME PERMITE TRABAJAR Y MANDAR AL FINALIZAR, PARA NO IR Y VENIR HACIA LA BD
                  var Unit = new UnitOfWork(context);

                  Unit.MedicoRepository.Delete(20);
                  Unit.RepositoryPaciente.Delete(66);

                  // Y MANDO LOS DOS  A LA VEZ

                  Unit.Save();





              };*/
            #endregion

            #region STRATEGY
            //recibe cualquier tipo que implemetne dicha interfaz
            var contextStrategy = new Context(new BikeStrategy());
  contextStrategy.Move(); 
  contextStrategy.Strategy = new CarStrategy(); // cambio de estrategia dinamicamente 
  contextStrategy.Move();


  #endregion
}
}
}
