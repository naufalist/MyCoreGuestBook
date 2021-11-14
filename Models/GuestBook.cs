using System;

namespace MyCoreGuestBook.Models
{
  public class GuestBook
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
  }
}