﻿using _531WorkoutApi.Domains;

namespace _531WorkoutApi.Repositories;

public interface IUserRepository
{
    Task AddAsync(User request);
}