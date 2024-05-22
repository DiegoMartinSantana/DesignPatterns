using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.BuilderGenerator
{

    public enum TypeFormat
    {
        Json,
        Pipes
    }
    public enum TypeCharacter
    {
        UpperCase,Normal,LowerCase
    }
    public interface IBuilderGenerator
    {
        public void Reset();
        public void SetContent(List<string> content);
        public void SetPath(string path);

        public void SetFormato(TypeFormat formato);
        public void SetCharacter(TypeCharacter character = TypeCharacter.Normal);

    }
}
