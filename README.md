# StoredProcedure C# Library
StoredProcedure

//parameter name and paramter values are respectively...

string[] ParameterNames = new string[] { Param_Name1, Param_Name2 };

string[] ParameterValues = new string[] { Param_Value1, Param_Value2 }; 

StoredProcedure sp = new StoredProcedure(YourConnectionString, YourSP_Name);

sp.WithParameter(ParameterNames,ParameterValues);

sp.WithoutParameter();
