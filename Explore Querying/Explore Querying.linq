<Query Kind="Expression" />

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
