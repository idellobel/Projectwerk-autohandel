using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.Abstract
{
    public interface TTextfileService
    {
        Task SaveText(string filename, string text);
        Task<string> LoadText(string filename);
    }
}
