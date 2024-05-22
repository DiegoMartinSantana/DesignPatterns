using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.BuilderGenerator
{
    public class GeneratorDirector
    {

        private IBuilderGenerator _builder;
        public GeneratorDirector(IBuilderGenerator builder)
        {
            SetBuilder(builder);    
        }
        public void SetBuilder(IBuilderGenerator builder)
        {
            _builder = builder;
        }   

        //generador de json
        public void CreateJson(List<string> content,string path)
        {
            _builder.Reset();
            _builder.SetPath(path);
            _builder.SetContent(content);
            _builder.SetFormato(TypeFormat.Json);

        }

        //generador de pipe
        public void CreatePipe(List<string> content,string path)
        {
            _builder.Reset();
            _builder.SetPath(path);
            _builder.SetContent(content);
            _builder.SetFormato(TypeFormat.Pipes);
            _builder.SetCharacter(TypeCharacter.UpperCase);
        }   
    }
}
