﻿using ToDoAppAPI.Tasks.Dtos;

namespace ToDoAppAPI.Dtos
{
    public class ListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<TaskDto>? Tasks { get; set; }

        public bool test() => true;
    }
}
