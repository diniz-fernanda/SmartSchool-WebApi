namespace SmartSchool_WebApi.Models
{
    public class Professor 
    {
        public Professor(){ }
        public Professor(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public IEnumerable<Disciplina> Disciplina { get; set; }
    }
}