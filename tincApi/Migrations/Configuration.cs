using System.Collections.Generic;
using tincApi.Models;

namespace tincApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<tincApi.DAL.TincContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(tincApi.DAL.TincContext context)
        {
            var desportos = new List<Desporto>
            {
                new Desporto
                {
                    ID=1,
                    Nome = "Atletismo",
                    Descricao = "Conjunto de desportos constituído por três modalidades: corrida, lançamentos e saltos.",
                    Responsavel = "LP"
                },
                new Desporto
                {
                    ID=2,
                    Nome = "BTT",
                    Descricao = "Modalidade de ciclismo na qual o objetivo é transpor percursos com diversas irregularidades e obstáculos.",
                    Responsavel = "LP"
                }
            };

            desportos.ForEach(d => context.Desporto.Add(d));
            context.SaveChanges();

            var eventos = new List<Evento>
            {
                new Evento
                {
                    ID = 1,
                    Nome="Corrida das cantarinhas",
                    Descricao = "Evento bla bla",
                    Responsavel = "LP",
                    Local="Bragança",
                    DataEvento = new DateTime(2017,09,18),
                    DesportoID = 1,
                    Website = "www.tinc.pt",
                    Inscricoes = true
                },
                new Evento
                {
                    ID = 2,
                    Nome="IPB4ALL",
                    Descricao = "ipb fun",
                    Responsavel = "LP",
                    Local="Bragança",
                    DataEvento = new DateTime(2018,01,01),
                    DesportoID = 1,
                    Website = "www.tinc.pt",
                    Inscricoes = true
                }
            };

            eventos.ForEach(e => context.Evento.Add(e));
            context.SaveChanges();

            var provas = new List<Prova>
            {
                new Prova
                {
                    ID = 1,
                    Nome="FamilyRace",
                    Descricao = "Prova de familia",
                    Responsavel = "LP",
                    Distancia = 5,
                    EventoID = 1
                },
                new Prova
                {
                    ID = 2,
                    Nome="FunRace",
                    Descricao = "Prova de amigos",
                    Responsavel = "LP",
                    Distancia = 15,
                    EventoID = 1
                },
                new Prova
                {
                    ID = 3,
                    Nome="Maratona",
                    Descricao = "Prova principal",
                    Responsavel = "LP",
                    Distancia = 33,
                    EventoID = 1
                },
                new Prova
                {
                    ID = 4,
                    Nome="Maratona IPB4all",
                    Descricao = "Prova principal",
                    Responsavel = "LP",
                    Distancia = 33,
                    EventoID = 2
                }
            };

            provas.ForEach(p => context.Prova.Add(p));
            context.SaveChanges();

            var categorias = new List<Categoria>
            {
                new Categoria
                {
                    ID = 1,
                    Nome="Familia",
                    Descricao = "",
                    Genero = "M/F",
                    IdadeMin = 6,
                    IdadeMax = 60,
                    TipoAtleta = "Caminhante",
                    Vencedores = 3,
                    ProvaID = 1
                },
                new Categoria
                {
                    ID = 2,
                    Nome="Amigos",
                    Descricao = "",
                    Genero = "M/F",
                    IdadeMin = 6,
                    IdadeMax = 60,
                    TipoAtleta = "Corredor",
                    Vencedores = 3,
                    ProvaID = 2
                },
                new Categoria
                {
                    ID = 3,
                    Nome="Infantil",
                    Descricao = "",
                    Genero = "M",
                    IdadeMin = 6,
                    IdadeMax = 12,
                    TipoAtleta = "Corredor",
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 4,
                    Nome="Infantil",
                    Descricao = "",
                    Genero = "F",
                    IdadeMin = 6,
                    IdadeMax = 12,
                    TipoAtleta = "Corredor",
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 5,
                    Nome="Junior",
                    Descricao = "",
                    Genero = "M",
                    IdadeMin = 13,
                    IdadeMax = 17,
                    TipoAtleta = "Corredor",
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 6,
                    Nome="Junior",
                    Descricao = "",
                    Genero = "F",
                    IdadeMin = 13,
                    IdadeMax = 17,
                    TipoAtleta = "Corredor",
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 7,
                    Nome="Senior",
                    Descricao = "",
                    Genero = "M",
                    IdadeMin = 18,
                    IdadeMax = 29,
                    TipoAtleta = "Corredor",
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 8,
                    Nome="Senior",
                    Descricao = "",
                    Genero = "F",
                    IdadeMin = 18,
                    IdadeMax = 29,
                    TipoAtleta = "Corredor",
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 9,
                    Nome="Veteranos",
                    Descricao = "",
                    Genero = "M",
                    IdadeMin = 30,
                    IdadeMax = 55,
                    TipoAtleta = "Caminhante",
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 10,
                    Nome="Veteranos",
                    Descricao = "",
                    Genero = "F",
                    IdadeMin = 30,
                    IdadeMax = 55,
                    TipoAtleta = "Caminhante",
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 11,
                    Nome="Volta ao IPB",
                    Descricao = "",
                    Genero = "M/F",
                    IdadeMin = 30,
                    IdadeMax = 55,
                    TipoAtleta = "Estudante",
                    Vencedores = 3,
                    ProvaID = 4
                }

            };

            categorias.ForEach(c => context.Categoria.Add(c));
            context.SaveChanges();

        }
    }
}
