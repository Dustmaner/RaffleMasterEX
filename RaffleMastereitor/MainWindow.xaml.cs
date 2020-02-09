using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace RaffleMastereitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Logger
        string logLines;

        // How many players
        int participantsNumber = 0;
        // Number of total rolls which have been had
        int totalRolls = 0;

        // global variable which allows keep track of each player's lives
        int[] lifeHolder = new int[8];

        // Random value generator
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Event of clicking button for Rolling Once
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vidasRoll(participantsNumber);
        }

        // Each of the options in the ComboBox
        private void itemSelected1(object sender, RoutedEventArgs e)
        {
            participantsNumber = vidasSetter(Convert.ToInt32(sender.ToString().Substring(38)));
        }

        private void itemSelected2(object sender, RoutedEventArgs e)
        {
            participantsNumber = vidasSetter(Convert.ToInt32(sender.ToString().Substring(38)));
        }

        private void itemSelected3(object sender, RoutedEventArgs e)
        {
            participantsNumber = vidasSetter(Convert.ToInt32(sender.ToString().Substring(38)));
        }

        private void itemSelected4(object sender, RoutedEventArgs e)
        {
            participantsNumber = vidasSetter(Convert.ToInt32(sender.ToString().Substring(38)));
        }

        private void itemSelected5(object sender, RoutedEventArgs e)
        {
            participantsNumber = vidasSetter(Convert.ToInt32(sender.ToString().Substring(38)));
        }

        private void itemSelected6(object sender, RoutedEventArgs e)
        {
            participantsNumber = vidasSetter(Convert.ToInt32(sender.ToString().Substring(38)));
        }

        private void itemSelected7(object sender, RoutedEventArgs e)
        {
            participantsNumber = vidasSetter(Convert.ToInt32(sender.ToString().Substring(38)));
        }

        private void itemSelected8(object sender, RoutedEventArgs e)
        {
            participantsNumber = vidasSetter(Convert.ToInt32(sender.ToString().Substring(38)));
            
        }

        // FUNCTION which sets the proper amount of "lives" of each player depending on how many will be playing
        int vidasSetter(int howMany)
        {
            vidasReSetter();

            if (howMany > 0) // IF players selected are more than 1 then populate the first spot
            {
                vidas1.Text = Convert.ToString(howMany - 0); // Give inverse oportunities to win (lives)
                lifeHolder[0] = (howMany - 0); // also update the non-visual holder of these values
            }
            if (howMany > 1)
            {
                vidas2.Text = Convert.ToString(howMany - 1);
                lifeHolder[1] = (howMany - 1);
            }
            if (howMany > 2)
            {
                vidas3.Text = Convert.ToString(howMany - 2);
                lifeHolder[2] = (howMany - 2);
            }
            if (howMany > 3)
            {
                vidas4.Text = Convert.ToString(howMany - 3);
                lifeHolder[3] = (howMany - 3);
            }
            if (howMany > 4)
            {
                vidas5.Text = Convert.ToString(howMany - 4);
                lifeHolder[4] = (howMany - 4);
            }
            if (howMany > 5)
            {
                vidas6.Text = Convert.ToString(howMany - 5);
                lifeHolder[5] = (howMany - 5);
            }
            if (howMany > 6)
            {
                vidas7.Text = Convert.ToString(howMany - 6);
                lifeHolder[6] = (howMany - 6);
            }
            if (howMany > 7)
            {
                vidas8.Text = Convert.ToString(howMany - 7);
                lifeHolder[7] = (howMany - 7);
            }

            return howMany;
        }

        // Resetter for when you change the number of players at any point
        void vidasReSetter()
        {
            lifeHolder[0] = 0;
            lifeHolder[1] = 0;
            lifeHolder[2] = 0;
            lifeHolder[3] = 0;
            lifeHolder[4] = 0;
            lifeHolder[5] = 0;
            lifeHolder[6] = 0;
            lifeHolder[7] = 0;
            vidas1.Text = Convert.ToString(0);
            vidas2.Text = Convert.ToString(0);
            vidas3.Text = Convert.ToString(0);
            vidas4.Text = Convert.ToString(0);
            vidas5.Text = Convert.ToString(0);
            vidas6.Text = Convert.ToString(0);
            vidas7.Text = Convert.ToString(0);
            vidas8.Text = Convert.ToString(0);
            resultadoDelRoll.FontSize = 28;
            resultadoDelRoll.Text = "♪New Day New Pencil♪";
            numeroDeRoll.Text = "Total rolls: 0";
        }

        // Good ol' roll
        void vidasRoll(int howMany)
        {
            //sb.WriteLine("asdf"); // log

            

            // IF no amount of players have been selected yet then no raffle will happen
            if (howMany == 0)
            {
                resultadoDelRoll.FontSize = 12; // the following message is wordy, so set font smaller
                resultadoDelRoll.Text = "Selecciona un numero de particicipantes primero";
            }
            // ELSE reduce the amount of "lives" a random player has
            else
            {
                resultadoDelRoll.FontSize = 36; // set a good readable size for the results text
                int dice = rnd.Next(1, (howMany+1)); // roll the dice and select a player
                if (lifeHolder[(dice - 1)] > 0) // IF player chosen still has enough lives
                {
                    lifeHolder[(dice - 1)] -= 1; // reduce the internal non-visual lives of the winner player
                    switch (dice)
                    {
                        case 1:
                            vidas1.Text = Convert.ToString(lifeHolder[(dice - 1)]); // Update the visual text in the table(grid)
                            resultadoDelRoll.Text = "Elegido: " + Convert.ToString(dice); // Update the big text which says who won this round
                            numeroDeRoll.Text = "Total rolls: " + ++totalRolls; // Update the total rolls which have been had by +1
                            logAction();
                            break;
                        case 2:
                            vidas2.Text = Convert.ToString(lifeHolder[(dice - 1)]);
                            resultadoDelRoll.Text = "Elegido: " + Convert.ToString(dice);
                            numeroDeRoll.Text = "Total rolls: " + ++totalRolls;
                            logAction();
                            break;
                        case 3:
                            vidas3.Text = Convert.ToString(lifeHolder[(dice - 1)]);
                            resultadoDelRoll.Text = "Elegido: " + Convert.ToString(dice);
                            numeroDeRoll.Text = "Total rolls: " + ++totalRolls;
                            logAction();
                            break;
                        case 4:
                            vidas4.Text = Convert.ToString(lifeHolder[(dice - 1)]);
                            resultadoDelRoll.Text = "Elegido: " + Convert.ToString(dice);
                            numeroDeRoll.Text = "Total rolls: " + ++totalRolls;
                            logAction();
                            break;
                        case 5:
                            vidas5.Text = Convert.ToString(lifeHolder[(dice - 1)]);
                            resultadoDelRoll.Text = "Elegido: " + Convert.ToString(dice);
                            numeroDeRoll.Text = "Total rolls: " + ++totalRolls;
                            logAction();
                            break;
                        case 6:
                            vidas6.Text = Convert.ToString(lifeHolder[(dice - 1)]);
                            resultadoDelRoll.Text = "Elegido: " + Convert.ToString(dice);
                            numeroDeRoll.Text = "Total rolls: " + ++totalRolls;
                            logAction();
                            break;
                        case 7:
                            vidas7.Text = Convert.ToString(lifeHolder[(dice - 1)]);
                            resultadoDelRoll.Text = "Elegido: " + Convert.ToString(dice);
                            numeroDeRoll.Text = "Total rolls: " + ++totalRolls;
                            logAction();
                            break;
                        case 8:
                            vidas8.Text = Convert.ToString(lifeHolder[(dice - 1)]);
                            resultadoDelRoll.Text = "Elegido: " + Convert.ToString(dice);
                            numeroDeRoll.Text = "Total rolls: " + ++totalRolls;
                            logAction();
                            break;
                    }
                }
                else // ELSE try again if a number was rolled but that player had no more lives
                {
                    // IF there are still rolls to be had
                    if ((lifeHolder[0] + lifeHolder[1] + lifeHolder[2] + lifeHolder[3] + lifeHolder[4] + lifeHolder[5] + lifeHolder[6] + lifeHolder[7]) > 0)
                    {
                        vidasRoll(howMany);
                    }
                    // Golden reference 'u'
                    else
                    {
                        resultadoDelRoll.FontSize = 28;
                        resultadoDelRoll.Text = "♪You've got nothing to play with♪";
                        using (StreamWriter outputFile = new StreamWriter("log.txt"))
                        {
                            //foreach (string line in logLines)
                            outputFile.WriteLine(logLines);
                        }
                    }
                }
            }
            

        }

        // FUNCTION for logging an action
        void logAction()
        {
            logLines = logLines + (resultadoDelRoll.Text + "\t" + numeroDeRoll.Text) + "\t Remaining lives: " +
                "\t1: " + lifeHolder[0] +
                "\t2: " + lifeHolder[1] +
                "\t3: " + lifeHolder[2] +
                "\t4: " + lifeHolder[3] +
                "\t5: " + lifeHolder[4] +
                "\t6: " + lifeHolder[5] +
                "\t7: " + lifeHolder[6] +
                "\t8: " + lifeHolder[7] + "\n";
        }

        // Buttons for when a player wishes to abstain
        private void instaKill1_Click(object sender, RoutedEventArgs e)
        {
            resultadoDelRoll.FontSize = 24;
            lifeHolder[0] = 0;
            vidas1.Text = Convert.ToString(0);
            resultadoDelRoll.Text = "Player 1 has successfully withdrawn";
        }
        private void instaKill2_Click(object sender, RoutedEventArgs e)
        {
            resultadoDelRoll.FontSize = 24;
            lifeHolder[1] = 0;
            vidas2.Text = Convert.ToString(0);
            resultadoDelRoll.Text = "Player 2 has successfully withdrawn";
        }
        private void instaKill3_Click(object sender, RoutedEventArgs e)
        {
            resultadoDelRoll.FontSize = 24;
            lifeHolder[2] = 0;
            vidas3.Text = Convert.ToString(0);
            resultadoDelRoll.Text = "Player 3 has successfully withdrawn";
        }
        private void instaKill4_Click(object sender, RoutedEventArgs e)
        {
            resultadoDelRoll.FontSize = 24;
            lifeHolder[3] = 0;
            vidas4.Text = Convert.ToString(0);
            resultadoDelRoll.Text = "Player 4 has successfully withdrawn";
        }
        private void instaKill5_Click(object sender, RoutedEventArgs e)
        {
            resultadoDelRoll.FontSize = 24;
            lifeHolder[4] = 0;
            vidas5.Text = Convert.ToString(0);
            resultadoDelRoll.Text = "Player 5 has successfully withdrawn";
        }
        private void instaKill6_Click(object sender, RoutedEventArgs e)
        {
            resultadoDelRoll.FontSize = 24;
            lifeHolder[5] = 0;
            vidas6.Text = Convert.ToString(0);
            resultadoDelRoll.Text = "Player 6 has successfully withdrawn";
        }
        private void instaKill7_Click(object sender, RoutedEventArgs e)
        {
            resultadoDelRoll.FontSize = 24;
            lifeHolder[6] = 0;
            vidas7.Text = Convert.ToString(0);
            resultadoDelRoll.Text = "Player 7 has successfully withdrawn";
        }
        private void instaKill8_Click(object sender, RoutedEventArgs e)
        {
            resultadoDelRoll.FontSize = 24;
            lifeHolder[7] = 0;
            vidas8.Text = Convert.ToString(0);
            resultadoDelRoll.Text = "Player 8 has successfully withdrawn";
        }
    }
}