using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePostApplication_Project1
{
    class App
    {
        public static void Run(User puser)  //Menu of Simple User level1
        {


            MenuManager.Basic(puser);


            int a = Convert.ToInt32(Console.ReadLine());
            //--------------------------------------------------------------------
            //---------------- Handler of Basic Menu  ----------------------------
            if (puser.Role == "SimpleUser")
            {
                // user = (SimpleUser)user;
                SimpleUser user = new SimpleUser()
                {
                    Username = puser.Username,
                    Password = puser.Password,
                    Role = puser.Role
                };

                if (a == 1)
                {
                    string sender = user.Username;

                    //-------------  Choose Receiver  -------------------------------------------------
                    Console.WriteLine("Choose Receiver");
                    DBCommands.PullUsers();

                    bool result = false;

                    string receiver;
                    do
                    {
                        receiver = Console.ReadLine();
                        if (DBCommands.FindUser(receiver))//check username in db
                        { result = true; }
                    } while (result == false);



                    //Take message
                    Console.WriteLine("Write Message");
                    string message = Console.ReadLine();
                    //Take time
                    DateTime now = DateTime.Now;
                    //New post
                    Post post = new Post()
                    {
                        SenderUsername = user.Username,
                        ReceiverUsername = receiver,
                        Message = message,
                        Date = now
                    };
                    //Send post to db
                    user.SendPost(post);

                    Console.WriteLine("It was sent successfully"); //++++ check function
                                                                   //Back
                    App.Run(user);

                }
                //All posts
                else if (a == 2)
                {
                    //See All Posts
                    Console.WriteLine("All Posts:");
                    user.PullPosts();

                    //Filter
                    /*   +++++++
                    string answer;
                    Console.WriteLine("Do you want to filter posts? \"yes\" or \"no\"");
                    answer = Console.ReadLine();
                    if (answer == "yes") {
                        i = 1;
                        Console.WriteLine("To filter by Sender, press {0}", i);i++;
                        Console.WriteLine("To filter by Receiver, press {0}", i); i++;
                        Console.WriteLine("To filter by Date, press{0}", i);
                     }
                    */

                    //Back
                    App.Run(user);
                }
                //Log out option
                else if (a == 0)
                {
                    user = null;
                    Console.WriteLine("Please, press a key to close Console Post App - beta version");

                }

            }
            else if (puser.Role == "Admin")
            {

                Admin user = new Admin()
                {
                    Username = puser.Username,
                    Password = puser.Password,
                    Role = puser.Role
                };

                if (a == 1)
                {
                    string sender = user.Username;

                    //-------------  Choose Receiver  -------------------------------------------------
                    Console.WriteLine("Choose Receiver");
                    DBCommands.PullUsers();

                    bool result = false;

                    string receiver;
                    do
                    {
                        receiver = Console.ReadLine();
                        if (DBCommands.FindUser(receiver))//check username in db
                        { result = true; }
                    } while (result == false);



                    //Take message
                    Console.WriteLine("Write Message");
                    string message = Console.ReadLine();
                    //Take time
                    DateTime now = DateTime.Now;
                    //New post
                    Post post = new Post()
                    {
                        SenderUsername = user.Username,
                        ReceiverUsername = receiver,
                        Message = message,
                        Date = now
                    };
                    //Send post to db
                    user.SendPost(post);

                    Console.WriteLine("It was sent successfully"); //++++ check function
                                                                   //Back
                    App.Run(user);

                }
                //All posts
                else if (a == 2)
                {
                    //See All Posts
                    Console.WriteLine("All Posts:");
                    user.PullPosts();

                    //Filter
                    /*   +++++++
                    string answer;
                    Console.WriteLine("Do you want to filter posts? \"yes\" or \"no\"");
                    answer = Console.ReadLine();
                    if (answer == "yes") {
                        i = 1;
                        Console.WriteLine("To filter by Sender, press {0}", i);i++;
                        Console.WriteLine("To filter by Receiver, press {0}", i); i++;
                        Console.WriteLine("To filter by Date, press{0}", i);
                     }
                    */
                    if (user.Role == "Admin")
                    {
                        a = 0;
                        Console.WriteLine("Do you want to edit any post? If yes, please insert its id. If no, type \"0\"");
                        a = Convert.ToInt32(Console.ReadLine());
                        if (a != 0)
                        {
                            bool result = false;
                            string message;
                            do
                            {
                                if (user.FindPost(a))
                                {
                                    do
                                    {
                                        Console.WriteLine("Please, type a new message (max=250 characters) and press Enter");
                                        message = Console.ReadLine();
                                    } while (message.Length > 250);
                                    result = user.EditPost(a, message);
                                }
                            } while (!result);
                        }
                    }

                    //Back
                    App.Run(user);
                }
                //Log out option
                else if (a == 0)
                {
                    user = null;
                    Console.WriteLine("Please, press a key to close Console Post App - beta version");

                }

            }
            else if (puser.Role == "SuperAdmin") 
            {

                SuperAdmin user = new SuperAdmin()
                {
                    Username = puser.Username,
                    Password = puser.Password,
                    Role = puser.Role
                };
                //Send Post
                if (a == 1)
                {
                    string sender = user.Username;

                    //-------------  Choose Receiver  -------------------------------------------------
                    Console.WriteLine("Choose Receiver");
                    DBCommands.PullUsers();

                    bool result = false;

                    string receiver;
                    do
                    {
                        receiver = Console.ReadLine();
                        if (DBCommands.FindUser(receiver))//check username in db
                        { result = true; }
                    } while (result == false);



                    //Take message
                    Console.WriteLine("Write Message");
                    string message = Console.ReadLine();
                    //Take time
                    DateTime now = DateTime.Now;
                    //New post
                    Post post = new Post()
                    {
                        SenderUsername = user.Username,
                        ReceiverUsername = receiver,
                        Message = message,
                        Date = now
                    };
                    //Send post to db
                    user.SendPost(post);

                    Console.WriteLine("It was sent successfully"); //++++ check function
                    //Back
                    App.Run(user);

                }
                //All posts
                else if (a == 2)
                {
                    //See All Posts
                    Console.WriteLine("All Posts:");
                    user.PullPosts();

                    //Filter
                    /*   +++++++
                    string answer;
                    Console.WriteLine("Do you want to filter posts? \"yes\" or \"no\"");
                    answer = Console.ReadLine();
                    if (answer == "yes") {
                        i = 1;
                        Console.WriteLine("To filter by Sender, press {0}", i);i++;
                        Console.WriteLine("To filter by Receiver, press {0}", i); i++;
                        Console.WriteLine("To filter by Date, press{0}", i);
                     }
                    */
                    if (user.Role == "Admin")
                    {
                        a = 0;
                        Console.WriteLine("Do you want to edit any post? If yes, please insert its id. If no, type \"0\"");
                        a = Convert.ToInt32(Console.ReadLine());
                        if (a != 0)
                        {
                            bool result = false;
                            string message;
                            do
                            {
                                if (user.FindPost(a))
                                {
                                    do
                                    {
                                        Console.WriteLine("Please, type a new message (max=250 characters) and press Enter");
                                        message = Console.ReadLine();
                                    } while (message.Length > 250);
                                    result = user.EditPost(a, message);
                                }
                            } while (!result);
                        }
                    }
                    else if (user.Role == "SuperAdmin")
                    {
                        a = 0;
                        char answer;
                        Console.WriteLine("Do you want to edit or delete any post? If you want to edit, type \"e\". If you want to delete,type \"d\". If you want to continue type any character");
                        answer = Convert.ToChar(Console.ReadLine());
                        if (answer == 'd' || answer == 'e')
                        {
                            Console.WriteLine("Please, type its id.");
                            a = Convert.ToInt32(Console.ReadLine());
                        }

                        if (answer == 'd')
                        {
                            do
                            {

                                if (user.FindPost(a))
                                {
                                    user.DeletePost(a);
                                }
                            } while (!user.FindPost(a));
                        }
                        else if (answer == 'e')
                        {

                            bool result = false;
                            string message;
                            do
                            {

                                while (!user.FindPost(a))
                                {
                                    Console.WriteLine("This id does not exist. Please, type the post id again!");
                                    a = Convert.ToInt32(Console.ReadLine());
                                }

                                do
                                {
                                    Console.WriteLine("Please, type a new message (max=250 characters) and press Enter");
                                    message = Console.ReadLine();
                                } while (message.Length > 250);

                                result = user.EditPost(a, message);

                            } while (!result);


                        }

                    }
                    //Back
                    App.Run(user);

                }
                //Roles
                else if (a == 3)
                {
                    if (user.Role == "SuperAdmin")
                    {
                        string username;
                        do
                        {
                            DBCommands.PullUsersRoles();
                            Console.WriteLine("Please,insert correct username: ");
                            username = Console.ReadLine();
                        } while (!DBCommands.FindUser(username));

                        string answer = "";

                        do
                        {
                            Console.WriteLine("Please, insert a valid Role (SimpleUser or Admin or SuperAdmin)");
                            answer = Console.ReadLine();

                        } while (!(answer == "Admin" || answer == "SuperAdmin" || answer == "SimpleUser"));
                        user.ChangeRoles(username, answer);
                        //Back
                        App.Run(user);

                    }
                }
                //Handle Users
                else if (a == 4)
                {
                    if (user.Role == "SuperAdmin")
                    {

                        int i = 1;
                        do
                        {
                            Console.WriteLine("To create any User, type: {0}", i); i++;
                            Console.WriteLine("To update any User, type: {0}", i); i++;
                            Console.WriteLine("To delete any User, type: {0}", i);
                            i = Convert.ToInt32(Console.ReadLine());
                        } while (!(i == 1 || i == 2 || i == 3));

                        if (i == 1)
                        {
                            Console.WriteLine("Insert a username");
                            string username = Console.ReadLine();
                            Console.WriteLine("Insert a password");
                            string password = Console.ReadLine();

                            user.CreateUser(username, password);

                        }
                        else if (i == 2)
                        {
                            do
                            {
                                Console.WriteLine("To change username, press 1");
                                Console.WriteLine("To change password, press 2");
                                i = Convert.ToInt32(Console.ReadLine());
                            }
                            while (!(i == 1 || i == 2));
                            //-------------------------------------- change username  ----------------------------
                            if (i == 1)
                            {
                                string username;

                                DBCommands.PullUsers();
                                do
                                {
                                    Console.WriteLine("Please,insert the old username: ");


                                    username = Console.ReadLine();
                                } while (!DBCommands.FindUser(username));

                                User temp = new User();
                                temp = temp.PullUser(username);

                                string answer = "";

                                Console.WriteLine("Please, insert new username.");
                                answer = Console.ReadLine();


                                user.ChangeUsername(temp, answer, user.Username);
                            }
                            
                            else if (i == 2)
                            { //change password
                                string username;

                                DBCommands.PullUsers();
                                do
                                {
                                    Console.WriteLine("Please,insert the old username: ");


                                    username = Console.ReadLine();
                                } while (!DBCommands.FindUser(username));

                                Console.WriteLine("Please insert new password!");
                                string pass = Console.ReadLine();
                                user.ChangePassword(username, pass);
                            }
                        }
                        else if (i == 3)
                        {
                            //delete user
                            string username;
                            do
                            {
                                DBCommands.PullUsersRoles();
                                Console.WriteLine("Please,insert the username of the User you want to delete: ");
                                username = Console.ReadLine();
                            } while (!DBCommands.FindUser(username));

                            user.DeleteUser(username, user.Username);
                        }
                        App.Run(user);

                    }
                }
                //Log out option
                else if (a == 0)
                {
                    user = null;
                    Console.WriteLine("Please, press any key to close Console Post App - beta version");

                }




            }


        }

    }
}
