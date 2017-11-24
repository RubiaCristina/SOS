CREATE TABLE [dbo].[PessoaDesaparecidas] (
    [Id]                    INT            IDENTITY (1, 1) NOT NULL,
    [DataDeDesaparecimento] DATETIME       NOT NULL,
    [Familiares]            NVARCHAR (MAX) NULL,
    [Local]                 NVARCHAR (MAX) NULL,
    [Como]                  NVARCHAR (MAX) NULL,
    [Pessoa_Id]             INT            NULL,
    CONSTRAINT [PK_dbo.PessoaDesaparecidas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.PessoaDesaparecidas_dbo.Pessoas_Pessoa_Id] FOREIGN KEY ([Pessoa_Id]) REFERENCES [dbo].[Pessoas] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Pessoa_Id]
    ON [dbo].[PessoaDesaparecidas]([Pessoa_Id] ASC);

