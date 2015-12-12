using AdventOfCode.Day7.Model.Abstractions;
using AdventOfCode.Day7.Model.Components;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Parser;
using NUnit.Framework;

namespace AdventOfCode.Day7.Tests
{
    [TestFixture]
    public class CircuitParserTests
    {
        [Test]
        public void ParseComponent_AndComponent()
        {
            // 1. Arrange
            const string input = "x AND y -> d";

            // 2. Act
            var result = new CircuitParser().ParseComponent(input);

            // 3. Assert
            var component = (AndComponent) result;

            Assert.AreEqual(ComponentTypeEnum.And, component.Type);
            Assert.AreEqual(ComponentInputTypeEnum.TwoComponent, component.InputType);
            Assert.IsTrue(component.InputNames.Contains("x"));
            Assert.IsTrue(component.InputNames.Contains("y"));
            Assert.AreEqual("d", component.OutputName);
        }

        [Test]
        public void ParseComponent_OrComponent()
        {
            // 1. Arrange
            const string input = "asdd OR yoyy -> dww";

            // 2. Act
            var result = new CircuitParser().ParseComponent(input);

            // 3. Assert
            var component = (OrComponent)result;

            Assert.AreEqual(ComponentTypeEnum.Or, component.Type);
            Assert.AreEqual(ComponentInputTypeEnum.TwoComponent, component.InputType);
            Assert.IsTrue(component.InputNames.Contains("asdd"));
            Assert.IsTrue(component.InputNames.Contains("yoyy"));
            Assert.AreEqual("dww", component.OutputName);
        }

        [Test]
        public void ParseComponent_NotComponent()
        {
            // 1. Arrange
            const string input = "NOT go -> gp";

            // 2. Act
            var result = new CircuitParser().ParseComponent(input);

            // 3. Assert
            var component = (NotComponent)result;

            Assert.AreEqual(ComponentTypeEnum.Not, component.Type);
            Assert.AreEqual(ComponentInputTypeEnum.OneComponent, component.InputType);
            Assert.AreEqual("go", component.InputName);
            Assert.AreEqual("gp", component.OutputName);
        }

        [Test]
        public void ParseComponent_RshiftComponent()
        {
            // 1. Arrange
            const string input = "x RSHIFT 5 -> aa";

            // 2. Act
            var result = new CircuitParser().ParseComponent(input);

            // 3. Assert
            var component = (RshiftComponent) result;

            Assert.AreEqual(ComponentTypeEnum.Rshift, component.Type);
            Assert.AreEqual(ComponentInputTypeEnum.OneWithParamComponent, component.InputType);
            Assert.AreEqual("x", component.InputName);
            Assert.AreEqual("aa", component.OutputName);
            Assert.AreEqual(5, component.Parameter);
        }

        [Test]
        public void ParseComponent_LshiftComponent()
        {
            // 1. Arrange
            const string input = "x LSHIFT 5 -> aa";

            // 2. Act
            var result = new CircuitParser().ParseComponent(input);

            // 3. Assert
            var component = (LshiftComponent)result;

            Assert.AreEqual(ComponentTypeEnum.Lshift, component.Type);
            Assert.AreEqual(ComponentInputTypeEnum.OneWithParamComponent, component.InputType);
            Assert.AreEqual("x", component.InputName);
            Assert.AreEqual("aa", component.OutputName);
            Assert.AreEqual(5, component.Parameter);
        }

        [Test]
        public void ParseComponent_InputComponent()
        {
            // 1. Arrange
            const string input = "133   -> dd";

            // 2. Act
            var result = new CircuitParser().ParseComponent(input);

            // 3. Assert
            var component = (InputComponent)result;

            Assert.AreEqual(ComponentTypeEnum.Input, component.Type);
            Assert.AreEqual(ComponentInputTypeEnum.OneComponent, component.InputType);
            Assert.AreEqual(133, component.Value);
            Assert.AreEqual("dd", component.OutputName);
        }

        [Test]
        public void ParseComponent_LinkComponent()
        {
            // 1. Arrange
            const string input = "b  -> dd";

            // 2. Act
            var result = new CircuitParser().ParseComponent(input);

            // 3. Assert
            var component = (LinkComponent)result;

            Assert.AreEqual(ComponentTypeEnum.Link, component.Type);
            Assert.AreEqual(ComponentInputTypeEnum.OneComponent, component.InputType);
            Assert.AreEqual("b", component.InputName);
            Assert.AreEqual("dd", component.OutputName);
        }
    }
}