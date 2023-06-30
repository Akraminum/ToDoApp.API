<Query Kind="Statements">
  <Connection>
    <ID>4da96ecb-3da5-4679-a19f-1af747877839</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="EF7Driver" PublicKeyToken="469b5aa5a4331a8c">EF7Driver.StaticDriver</Driver>
    <CustomAssemblyPath>E:\02.Play Ground\ToDoApp\ToDoAppAPI\bin\Debug\net6.0\ToDoAppAPI.dll</CustomAssemblyPath>
    <CustomTypeName>ToDoAppAPI.DataBase.AppDbContext</CustomTypeName>
    <CustomCxString>server=.;database=ToDoApp;trusted_connection=true;TrustServerCertificate=True;</CustomCxString>
    <DriverData>
      <UseDbContextOptions>true</UseDbContextOptions>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

Lists.Include(l =>
	l.Tasks.Where(t => 
    	t.Title.Contains("p")))


Lists.Where(l => l.Name.Contains("p"))
.Include(l =>
	l.Tasks.Where(t => 
    	t.Title.Contains("p")))
		
		

		


