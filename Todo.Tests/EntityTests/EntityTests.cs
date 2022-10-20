using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Todo.Tests.EntityTests
{
    [TestClass]
    public class EntityTests
    {
        private readonly TodoItem _validTodoItem =
            new("Estudar", DateTime.Now, "Gabriel Almeida");

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_novo_todo_o_mesmo_deve_vir_desmarcado()
        {
            Assert.IsFalse(_validTodoItem.Done);
        }
    }
}