using NotesAPI;

namespace NotesProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<NotesModel> Notes = new List<NotesModel>();
            NotesManager notesManager = new NotesManager();
            int Choice;
            try
            {
                do
                {
                    Console.WriteLine("Welcome to the Notes! Please select your option!\n1 - New Note\n2 - Delete Note\n3 - Edit Note\n4 - Show Notes\n5 - Search Notes\n6 - Exit");
                    Choice = Convert.ToInt32(Console.ReadLine());
                    switch (Choice)
                    {
                        case 1:
                            notesManager.AddingNotes(Notes);
                            break;

                        case 2:
                            notesManager.DeleteNotes(Notes);
                            break;

                        case 3:
                            notesManager.EditNotes(Notes);
                            break;

                        case 4:
                            notesManager.ShowNotes(Notes);
                            break;
                        
                        case 5: notesManager.SearchNotes(Notes);
                            break;

                        case 6:
                            Console.WriteLine("Exited!");
                            break;

                        default:
                            Console.WriteLine("Enter a valid number!");
                            break;
                    }
                }while (Choice != 6);
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a valid value!");
            }

        }
    }
}
