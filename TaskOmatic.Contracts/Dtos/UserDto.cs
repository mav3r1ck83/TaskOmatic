﻿namespace TaskOmatic.Contracts.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Created { get; set; }
}