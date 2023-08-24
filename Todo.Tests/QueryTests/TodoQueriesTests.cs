namespace Todo.Tests.QueryTests
{
    [TestClass]
    public class TodoQueriesTests
    {
        private readonly List<TodoItem> _todoItems;

        public TodoQueriesTests()
        {
            _todoItems = new List<TodoItem>()
            {
                new TodoItem("Estudar", DateTime.Now, "Gabriel"),
                new TodoItem("Jogar", DateTime.Now, "Eduardo"),
                new TodoItem("Sair para beber", DateTime.Now, "Gabriel"),
                new TodoItem("Treinar", DateTime.Now, "Eduardo"),
                new TodoItem("Comprar roupas", DateTime.Now, "Carolina"),
            };
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_deve_retornar_todas_as_tarefas_de_um_usuario_especifico()
        {
            var result = _todoItems.AsQueryable().Where(TodoQueries.GetAll("Gabriel")).ToList();
            Assert.AreEqual(2, result.Count);
        }
    }
}