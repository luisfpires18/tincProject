using System.Collections.Generic;
using tincApi.Models;
using tincApi.Models.Enum;

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

            desportos.ForEach(d => context.Desporto.AddOrUpdate(d));
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

            eventos.ForEach(e => context.Evento.AddOrUpdate(e));
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

            provas.ForEach(p => context.Prova.AddOrUpdate(p));
            context.SaveChanges();

            var categorias = new List<Categoria>
            {
                new Categoria
                {
                    ID = 1,
                    Nome="Familia",
                    Descricao = "",
                    Genero = Genero.Ambos,
                    IdadeMin = 6,
                    IdadeMax = 60,
                    TipoAtleta = Atleta.Caminhante,
                    Vencedores = 3,
                    ProvaID = 1
                },
                new Categoria
                {
                    ID = 2,
                    Nome="Amigos",
                    Descricao = "",
                    Genero = Genero.Ambos,
                    IdadeMin = 6,
                    IdadeMax = 60,
                    TipoAtleta = Atleta.Corredor,
                    Vencedores = 3,
                    ProvaID = 2
                },
                new Categoria
                {
                    ID = 3,
                    Nome="Infantil",
                    Descricao = "",
                    Genero = Genero.Masculino,
                    IdadeMin = 6,
                    IdadeMax = 12,
                    TipoAtleta = Atleta.Corredor,
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 4,
                    Nome="Infantil",
                    Descricao = "",
                    Genero = Genero.Feminino,
                    IdadeMin = 6,
                    IdadeMax = 12,
                    TipoAtleta = Atleta.Corredor,
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 5,
                    Nome="Junior",
                    Descricao = "",
                    Genero = Genero.Masculino,
                    IdadeMin = 13,
                    IdadeMax = 17,
                    TipoAtleta = Atleta.Corredor,
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 6,
                    Nome="Junior",
                    Descricao = "",
                    Genero = Genero.Feminino,
                    IdadeMin = 13,
                    IdadeMax = 17,
                    TipoAtleta = Atleta.Corredor,
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 7,
                    Nome="Senior",
                    Descricao = "",
                    Genero = Genero.Masculino,
                    IdadeMin = 18,
                    IdadeMax = 29,
                    TipoAtleta = Atleta.Corredor,
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 8,
                    Nome="Senior",
                    Descricao = "",
                    Genero = Genero.Feminino,
                    IdadeMin = 18,
                    IdadeMax = 29,
                    TipoAtleta = Atleta.Corredor,
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 9,
                    Nome="Veteranos",
                    Descricao = "",
                    Genero = Genero.Masculino,
                    IdadeMin = 30,
                    IdadeMax = 55,
                    TipoAtleta = Atleta.Caminhante,
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 10,
                    Nome="Veteranos",
                    Descricao = "",
                    Genero = Genero.Feminino,
                    IdadeMin = 30,
                    IdadeMax = 55,
                    TipoAtleta = Atleta.Caminhante,
                    Vencedores = 3,
                    ProvaID = 3
                },
                new Categoria
                {
                    ID = 11,
                    Nome="Volta ao IPB",
                    Descricao = "",
                    Genero = Genero.Ambos,
                    IdadeMin = 30,
                    IdadeMax = 55,
                    TipoAtleta = Atleta.Corredor,
                    Vencedores = 3,
                    ProvaID = 4
                }

            };

            categorias.ForEach(c => context.Categoria.AddOrUpdate(c));
            context.SaveChanges();

            var equipas = new List<Equipa>
            {
                new Equipa{ ID = 1, Nome = "Individual"},
                new Equipa{ ID = 2, Nome = "GD Bragança"},
                new Equipa{ ID = 3, Nome = "SL Benfica"},
                new Equipa{ ID = 4, Nome = "FC Porto"},
                new Equipa{ ID = 5, Nome = "Sporting CP"},
                new Equipa{ ID = 6, Nome = "SC Braga"},
                new Equipa{ ID = 7, Nome = "Vitoria SC"},
                new Equipa{ ID = 8, Nome = "Rio Ave FC"}
            };
            equipas.ForEach(e => context.Equipa.AddOrUpdate(e));
            context.SaveChanges();

            var pessoas = new List<Pessoa>
            {
                new Pessoa
                {
                    ID= 1,
                    Nome = "Luis Pires",
                    DataNascimento = new DateTime(1992,09,18),
                    Cidade = "Bragança",
                    Contacto = "936854524",
                    Email = "luis.pires@itsector.pt",
                    EquipaID = 3,
                    Nacionalidade = "Portuguesa",
                    Genero = Sexo.Masculino
                },
                new Pessoa
                {
                    ID= 2,
                    Nome = "Daniel Cidre",
                    DataNascimento = new DateTime(1995,08,20),
                    Cidade = "Valpaços",
                    Contacto = "912121211",
                    Email = "danielcidre@aestig.pt",
                    EquipaID = 4,
                    Nacionalidade = "Francesa",
                    Genero = Sexo.Masculino
                },
                new Pessoa
                {
                    ID= 3,
                    Nome = "José Rocha",
                    DataNascimento = new DateTime(1994,06,02),
                    Cidade = "Lousada",
                    Contacto = "912121211",
                    Email = "jose.rocha@itsector.pt",
                    EquipaID = 4,
                    Nacionalidade = "Portuguesa",
                    Genero = Sexo.Masculino
                }
            };

            pessoas.ForEach(p => context.Pessoa.AddOrUpdate(p));
            context.SaveChanges();



        }
    }
}
