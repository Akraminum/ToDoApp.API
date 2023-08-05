-- Include

SELECT [l].[Id], [t].[Id], [t].[DateCompleted], [t].[DateCreated], [t].[DateDue], [t].[Description], [t].[IsComplete], [t].[ListId], [t].[OwnerId], [t].[PriorityId], [t].[Title], [t].[UserCompletedId]
FROM [Lists] AS [l]
LEFT JOIN [Tasks] AS [t] ON [l].[Id] = [t].[ListId]
WHERE [l].[Id] = @__id_0
ORDER BY [l].[Id]