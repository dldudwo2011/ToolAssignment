var builder = WebApplication.CreateBuilder(args);
// Add services to the container
builder.Services.AddControllers();
var app = builder.Build();
// Configure the HTTP request pipeline
app.UseRouting();
app.MapControllers();
app.Run();

 bool IsPrime(int number)
{
    if (number <= 1)
        return false;

    for (int i = 2; i <= Math.Sqrt(number); i++)
    {
        if (number % i == 0)
            return false;
    }
    return true;
}

int BinaryToDecimal(string binary)
{
    int decimalValue = 0;
    int baseValue = 1; // 2^0

    for (int i = binary.Length - 1; i >= 0; i--)
    {
        if (binary[i] == '1')
            decimalValue += baseValue;

        baseValue *= 2;
    }
    return decimalValue;
}

string DecimalToBinary(int number)
{
    if (number == 0)
        return "0";

    string binary = "";

    while (number > 0)
    {
        binary = (number % 2) + binary;
        number /= 2;
    }

    return binary;
}