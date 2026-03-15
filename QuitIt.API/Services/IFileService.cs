using System;
using QuitIt.API.Models;

namespace QuitIt.API.Services;

public interface IFileService<T>
{
    List<T> LoadData();
    Task SaveData(List<T> data);
}
