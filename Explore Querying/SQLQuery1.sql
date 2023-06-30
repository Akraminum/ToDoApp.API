

SELECT [Username], [Name] as list
FROM Users
LEFT Join [dbo].[UsersLists]
	ON [UsersLists].UserId = [Users].Id
LEFT Join [Lists]
	ON [Lists].Id = [UsersLists].ListId
