using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Todo.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        private readonly CreateTodoCommand _titlelessInvalidCommand =
            new CreateTodoCommand("", "Gabriel Almeida", DateTime.Now);

        private readonly CreateTodoCommand _validCommand =
            new CreateTodoCommand("Programar", "Gabriel Almeida", DateTime.Now);

        [TestMethod]
        [TestCategory("Commands")]
        public void Dado_um_comando_invalido_o_mesmo_deve_falhar()
        {
            Assert.IsFalse(_titlelessInvalidCommand.Validate().IsValid);
            Assert.AreEqual(1, _titlelessInvalidCommand.Validate().Errors.Count);
        }

        [TestMethod]
        [TestCategory("Commands")]
        public void Dado_um_comando_valido_o_mesmo_deve_passar()
        {
            Assert.IsTrue(_validCommand.Validate().IsValid);
            Assert.AreEqual(0, _validCommand.Validate().Errors.Count);
        }
    }
}