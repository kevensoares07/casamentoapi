using System.Collections.Generic;
using System.Threading.Tasks;
using ApiMatheus.Data;
using ApiMatheus.DTOs;
using ApiMatheus.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiMatheus.Services
{
    public class PresenteService
    {
        private readonly AppDbContext _context;

        public PresenteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Presente>> BuscarTodosPresentes()
        {
            return await _context.Presentes.ToListAsync();
        }

        public async Task<bool> ConfirmarPresente(int presenteId, string pessoa)
        {
            var presente = await _context.Presentes.FindAsync(presenteId);
            if (presente == null || presente.Confirmado)
                return false;

            presente.Confirmado = true;
            presente.PessoaConfirmada = pessoa;

            _context.Presentes.Update(presente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EscolherPresente(int convidadoId, int presenteId)
        {
            var convidado = await _context.Convidados.FindAsync(convidadoId);
            var presente = await _context.Presentes.FindAsync(presenteId);
            
            if (convidado == null || presente == null || presente.Confirmado)
                return false;

            convidado.PresenteId = presenteId;
            presente.Confirmado = true;

            _context.Entry(convidado).State = EntityState.Modified;
            _context.Entry(presente).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CriarPresente(ConfirmarPresenteDto presenteDto)
        {
            var presente = new Presente
            {
                Nome = presenteDto.Nome
            };

            _context.Presentes.Add(presente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}