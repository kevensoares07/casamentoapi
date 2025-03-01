using System.Threading.Tasks;
using ApiMatheus.Data;
using ApiMatheus.DTOs;
using ApiMatheus.Models;

namespace ApiMatheus.Services
{
    public class ConvidadoService
    {
        private readonly AppDbContext _context;

        public ConvidadoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CriarConvidado(ConfirmarConvidadoDto dto)
        {
            // Cria um novo registro de Convidado utilizando apenas o nome
            var convidado = new Convidado
            {
                Nome = dto.Nome,
                PresenteId = null  // Não atribui presente, conforme solicitado
            };

            _context.Convidados.Add(convidado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}