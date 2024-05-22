using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.BuilderGenerator;

namespace Tools.BuilderGenerator
{
    public class GeneratorConcreteBuilder : IBuilderGenerator
    {
        private Generator _generator;

        public GeneratorConcreteBuilder()
        {
            Reset();
        }

        //metodo para devolver
        public Generator GetGenerator()
        {
            return _generator;
        }

        public void Reset()
        {
            _generator = new Generator();
        }

        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal)
        {
            _generator.Character = character;
        }

        public void SetContent(List<string> content)
        {
           _generator.Content= content;
        }

        public void SetFormato(TypeFormat formato)
        {
            _generator.Formato = formato;
        }

        public void SetPath(string path)
        {
            _generator.Path = path;
        }
    }
}
