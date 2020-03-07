using System;
using TC.Core.Contracts;
using TC.Core.Utilities;
using TC.Core.Utilities.IO.Contracts;
using TC.Core.Validation;
using TC.Services.Contracts;

namespace TC.Core
{
    public class Engine : IEngine
    {
        private readonly ISalaryService salaryService;
        private readonly IWriter writer;
        private readonly IReader reader;

        public Engine(ISalaryService salaryService,
                      IWriter writer,
                      IReader reader)
        {
            this.salaryService = salaryService 
                ?? throw new ArgumentNullException(nameof(salaryService));
            this.writer = writer
                ?? throw new ArgumentNullException(nameof(writer));
            this.reader = reader
                ?? throw new ArgumentNullException(nameof(reader));
        }

        public void Run()
        {
            writer.WriteLine(GlobalMessages.welcomeMessage);
            var input = string.Empty;

            while (input != "stop")
            {
                writer.Write(GlobalMessages.enterSalaryMsg);
                input = reader.ReadLine();

                try
                {
                    input.IsValidInput();
                    var result = salaryService.CalculateNetSalary(decimal.Parse(input));
                    writer.WriteLine(string.Format(GlobalMessages.netSalaryResult,result));
                }
                catch (Exception ex)
                {
                    writer.WriteLineRedColor(ex.Message);
                }
            }
        }
    }
}
