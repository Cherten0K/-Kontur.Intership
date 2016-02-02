using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khanab
{
    [Serializable]
    public class MoveException : Exception
    {
        public MoveException() { }
        public MoveException(string message) : base(message) { }
        public MoveException(string message, Exception inner) : base(message, inner) { }
        protected MoveException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    class PlayGame
    {
        const String START_GAME_LABEL = "Start new";
        const String PLAY_CARD_LABEL = "Play card";
        const String DROP_CARD_LABEL = "Drop card";
        const String TELL_COLOR_LABEL = "Tell color";
        const String TELL_RANK_LABEL = "Tell rank";

        const String BLUE_LABEL = "Blue";
        const String GREEN_LABEL = "Green";
        const String RED_LABEL = "Red";
        const String WHITE_LABEL = "White";
        const String YELLOW_LABEL = "Yellow";        

        public static void Main()
        {
            String input = "";
            Khanab game = new Khanab();
            while ((input = Console.ReadLine()) != null)
            {
                string[] inputs = input.Split(' ');
                switch (String.Join(" ", inputs.Take(2)))
                {
                    case START_GAME_LABEL:
                        game.StartGame(inputs.Skip(5));
                        break;
                    case PLAY_CARD_LABEL:
                        //game.PlayCard(Int32.Parse(inputs.Last()));
                        break;
                    case DROP_CARD_LABEL:
                        //game.DropCard(Int32.Parse(inputs.Last()));
                        break;
                    case TELL_COLOR_LABEL:
                        ColorCard chosenColor = ColorCard.blue;
                        switch (inputs[2])
	                    {
                            case GREEN_LABEL:
                                chosenColor = ColorCard.green;
                                break;
                            case RED_LABEL:
                                chosenColor = ColorCard.red;
                                break;
                            case WHITE_LABEL:
                                chosenColor = ColorCard.white;
                                break;
                            case YELLOW_LABEL: 
                                chosenColor = ColorCard.yellow;
                                break;
		                    default:
                                break;
	                    }
                        //game.TellColor(chosenColor, inputs.Skip(5).Select(str => Int32.Parse(str)));
                        break;
                    case TELL_RANK_LABEL:
                        //
                        break;
                    default:
                        break;
                }
            }
        }
    }
    public class Khanab : IGame
    {

        public int Turn
        {
            get;
        }

        public int CorrectCards
        {
            get;
        }

        public int RiskCars
        {
            get;
        }

        public IPlayer Player1
        {
            get;
        }

        public IPlayer Player2
        {
            get;
        }

        public void StartGame(IList<string> cards)
        {
            Player1 = new Player(cards.Take(5));

        }

        public event IGame.PlayDropCardEventHadler PlayCardEvent;

        public event IGame.PlayDropCardEventHadler DropCardEvent;

        public event IGame.TellColorEventHandler TellColorEvent;

        public event IGame.TellRankEventHandler TellRankEvent;

        public void ChangePlayersAfterGame(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void StopGame()
        {
            throw new NotImplementedException();
        }
    }

    public class Player : IPlayer
    {
        public IList<Card> Cards
        {
            get;
            private set;
        }

        public void PlayCard(int i)
        {
            throw new NotImplementedException();
        }

        public void DropCard(int i)
        {
            throw new NotImplementedException();
        }

        public void TellColor(ColorCard color, IEnumerable<int> numberCards)
        {
            throw new NotImplementedException();
        }

        public void TellRank(int rank, IList<int> numberCards)
        {
            throw new NotImplementedException();
        }


        public Player(IList<String> cards)
        {
            Cards = new List<Card>();
            foreach (var card in cards)
            {
                Cards.Add(new Card(card));
            }
        }
    }

    public interface IPlayer
    {
        IList<Card> Cards { get; private set; }

        public void PlayCard(int i);
        public void DropCard(int i);
        public void TellColor(ColorCard color, IEnumerable<int> numberCards);
        public void TellRank(int rank, IList<int> numberCards);
    }
    public interface IGame
    {
        public delegate void PlayDropCardEventHadler(int i);
        public delegate void TellColorEventHandler(ColorCard color, IEnumerable<int> numberCards);
        public delegate void TellRankEventHandler(int rank, IEnumerable<int> numberCards);

        int Turn { get; private set; }
        int CorrectCards { get; private set; }
        int RiskCars { get; private set; }

        IPlayer Player1 { get; private set; }
        IPlayer Player2 { get; private set; }


        IList<Card> Deck;
        IEnumerable<Card> Board;

        public void StartGame(IEnumerable<String> cards);

        public event PlayDropCardEventHadler PlayCardEvent;
        public event PlayDropCardEventHadler DropCardEvent;
        public event TellColorEventHandler TellColorEvent;
        public event TellRankEventHandler TellRankEvent;

        void ChangePlayersAfterGame(object sender, EventArgs e);

        public void StopGame();
    }

    enum ColorCard
    {
        red,
        green,
        blue,
        yellow,
        white
    }

    class Card
    {
        const char BLUE_LABEL = 'B';
        const char GREEN_LABEL = 'G';
        const char RED_LABEL = 'R';
        const char WHITE_LABEL = 'W';
        const char YELLOW_LABEL = 'Y';

        ColorCard Color { get; set; }
        int Quality { get; set; }

        Card(String card): this(card, Int32.Parse(card[1].ToString()))
        {
        }

        Card(String card, int quality)
        {
            switch (card[0])
            {
                case BLUE_LABEL:
                    Color = ColorCard.blue;
                    break;
                case GREEN_LABEL:
                    Color = ColorCard.green;
                    break;
                case RED_LABEL:
                    Color = ColorCard.red;
                    break;
                case WHITE_LABEL:
                    Color = ColorCard.white;
                    break;
                case YELLOW_LABEL:
                    Color = ColorCard.yellow;
                    break;
                default:
                    Color = ColorCard.blue;
                    break;
            }
            Quality = quality;
        }
    }
}
