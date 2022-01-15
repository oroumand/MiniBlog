using MiniBlog.Core.ApplicationService.Writers.Commands.CreateWriter;
using MiniBlog.Core.Contracts.Writers.Commands.CreateWriter;
using FluentValidation.TestHelper;
using Zamin.Utilities.Services.Localizations;
using Moq;
using Xunit;

namespace MiniBlog.Core.ApplicationService.Test.Writers.Commands.CreateWriter;
public class CreateWriterCommandValidatorTest
{
    [Theory]
    [InlineData(null, "Required")]
    [InlineData("", "Required")]
    [InlineData("a", "MinimumLength")]
    [InlineData("12345678900987654321123456", "MaximumLength")]
    public void chek_first_name_invalid_values(string firstName, string code)
    {
        var translatorMoq = new Mock<ITranslator>();
        translatorMoq.Setup(c => c[It.IsAny<string>()]).Returns("Message");
        translatorMoq.Setup(c => c[It.IsAny<string>(), It.IsAny<string>()]).Returns("Message");
        translatorMoq.Setup(c => c[It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()]).Returns("Message");
        translatorMoq.Setup(c => c[It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()]).Returns("Message");
        translatorMoq.Setup(c => c[It.IsAny<string>() ,It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()]).Returns("Message");
        CreateWriterCommandValidator validator = new(translatorMoq.Object);
        
        CreateWriterCommand writer = new();
        writer.FirstName = firstName;

        var validationTestResult = validator.TestValidate(writer);
        validationTestResult.ShouldHaveValidationErrorFor(c => c.FirstName).WithErrorCode(code);

    }
}
