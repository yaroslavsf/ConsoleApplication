using _01_Console_App.Helpers;

namespace UnitTest
{
    public class UnitTest
    {
        enum ETest
        {
            EXIT = 0,
            OPERATION
        }
        [Fact]
        public void Input_OperationInteraction_PersistsInLog()
        {          
            // Arrange
            string inputString = "1";
            StringReader stringReader = new StringReader(inputString);            
            List<Interaction> mockList = new List<Interaction>() { new Input(ETest.OPERATION) };
            InteractionHandler interactionHandler = new();
            
            // Act
            Console.SetIn(stringReader);            
            interactionHandler.NumberInput(typeof(ETest));            
           
            // Assert
            Assert.Equivalent(mockList, interactionHandler.Interactions);               
        }

        [Fact]
        public void Input_NumberInteraction_PersistsInLog()
        {
            // Arrange
            string inputString = "5";
            StringReader stringReader = new StringReader(inputString);
            InteractionHandler interactionHandler = new();

            // Act
            Console.SetIn(stringReader);            
            interactionHandler.NumberInput();

            //Assert
            List<Interaction> mockList = new List<Interaction>() { new Input(int.Parse(inputString)) };
            Assert.Equivalent(mockList, interactionHandler.Interactions);
        }

        [Fact]
        public void Input_StringInteraction_PersistsInLog()
        {
            // Arrange
            string inputString = "qwe";
            StringReader stringReader = new StringReader(inputString);
            InteractionHandler interactionHandler = new();

            // Act
            Console.SetIn(stringReader);
            interactionHandler.StringInput();

            //Assert
            List<Interaction> mockList = new List<Interaction>() { new Input(inputString) };
            Assert.Equivalent(mockList, interactionHandler.Interactions);
        }

        [Fact]
        public void Output_StringInteraction_PersistsInLog()
        {
            // Arrange
            string inputString = "die Liste: [someList]";           
            InteractionHandler interactionHandler = new();

            // Act            
            interactionHandler.Output(inputString);

            //Assert
            List<Interaction> mockList = new List<Interaction>() {
                new Output(inputString, ((Output)interactionHandler.Interactions[0]).Zeitpunkt)
            };
            Assert.Equivalent(mockList, interactionHandler.Interactions);
        }

    }
}