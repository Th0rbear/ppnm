using static System.Console;

class Test{
	static void Main(){
		Write($"my max int = {machineepsilon.maxOrMinInt(true)}\n");
		Write($"int.MaxValue = {int.MaxValue}\n");
		Write($"my min int = {machineepsilon.maxOrMinInt(false)}\n");
		Write($"int.MinValue = {int.MinValue}\n");
		Write($"my min double = {machineepsilon.precDAndF().Item1}\n");
		Write($"should be about: {System.Math.Pow(2, -52)}\n");
		Write($"my min float = {machineepsilon.precDAndF().Item2}\n");
		Write($"should be about: {System.Math.Pow(2, -23)}\n");
		machineepsilon.sumAAndSumB();
		Write($"for a=1.0 & b=1+1.0e-10 then approx should give true: {machineepsilon.approx(1.0, 1.0000000001, 1e-9, 1e-9)}\n");
		Write($"for a=1.0 & b=1+1.0e-9 then we hit 2nd condition in approx, and it should                      give true: {machineepsilon.approx(1.0, 1.000000001, 1e-9, 1e-9)}\n");
		Write($"for a=1.0 & b=1.2 then approx should give false: {machineepsilon.approx(1.0, 1.2, 1e-9, 1e-9)}\n");
	}
}
