using System.ComponentModel.DataAnnotations;

namespace OrganizadordeTarefas.Models;

public class Tarefa
{
    public int Id { get; set; }
    [Display(Name = "Título")]
    public string Titulo { get; set; }
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Display(Name = "Data da Tarefa")]
    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
    public DateTime Data { get; set; }
    public EnumStatusTarefa Status { get; set; }
}
