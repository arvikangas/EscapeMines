using EscapeMines.Models;

namespace EscapeMines.Services
{
    public interface ITurtleMoverService
    {
        Result Run(Input input);
    }
}
