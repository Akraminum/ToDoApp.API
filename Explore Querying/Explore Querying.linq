<Query Kind="Expression">
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

// toooo BAD
//Lists.Include(l => l.Users).Where(l => l.Users.All(u => u.Id == 1)).Select(l=>l)


//from list in Lists
//join userlist in UsersLists on list.Id equals userlist.UserId 
//join user in Users on userlist.UserId equals user.Id
//where user.Id == 1
//select list
,

from list in Lists
 join userlist in UsersLists on list.Id equals userlist.UserId
 where userlist.UserId == 1
 select list
 ,
 
//UsersLists.Include(ul => ul.List).Where(ul => ul.UserId == 1)
