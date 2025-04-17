using CardServConvert.Dto;
using FluentValidation;
using System.Globalization;

namespace CardServConvert.Validator
{
    public class ControlCardValidator : AbstractValidator<ControlCardDto>
    {
        public ControlCardValidator()
        {
            RuleFor(x => x.ManufacturerId).NotEmpty();

            RuleFor(x => x.MeterType)
            .NotEmpty()
            .WithMessage("MeterType is Required.")
            .Matches(@"^[0-9]$")
            .WithMessage("MeterType Must be a Integer");

            RuleFor(x => x.MeterVersion).NotEmpty();
            RuleFor(x => x.CardId).NotEmpty();
            RuleFor(x => x.DistributionCompanyCode).NotEmpty();
            RuleFor(x => x.SectorCode).NotEmpty();

            RuleFor(x => x.ActivationDate)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage("Activation Date Format Must be [dd-MM-yyyy] .");

            RuleFor(x => x.ExpiryDate)
                .NotEmpty()
                .Must(IsAValidDate)
                .WithMessage("Expiry Date Format Must be [dd-MM-yyyy] .");
        }

        private bool IsAValidDate(string dateStr)
        {
            return DateTime.TryParseExact(
            dateStr,
            "dd-MM-yyyy",
             CultureInfo.InvariantCulture,
             DateTimeStyles.None,
             out _);
        }
    }
}
