using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Tests.Repositories;

namespace Todo.Tests.HandlersTests
{
    [TestClass]
    public class CreateTodoHandlerTests
    {
        private readonly CreateTodoCommand _titlelessInvalidCommand =
            new("", "Gabriel Almeida", DateTime.Now);

        private readonly CreateTodoCommand _validCommand =
            new("Programar", "Gabriel Almeida", DateTime.Now);

        private readonly TodoHandler _handler = new(new FakeTodoRepository(), new NotificationContext());

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_invalido_deve_retornar_falha()
        {
            var result = (GenericCommandResponse)_handler.Handle(_titlelessInvalidCommand);
            Assert.IsFalse(result.Success);
        }

        [TestMethod]
        [TestCategory("Handlers")]
        public void Dado_um_comando_valido_deve_criar_um_todoItem()
        {
            var result = (GenericCommandResponse)_handler.Handle(_validCommand);
            Assert.IsTrue(result.Success);
        }
    }
}