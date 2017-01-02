using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Resources;
using Monopoli.Model;

namespace Monopoli.Controller
{
    class DefaultConfigLoader : IConfigLoader
    {
        private List<Casella> _cells;
        private List<Carta> _cards;
        private TavolaDaGioco _playBoard;
        private int _cellNum;
        private Dictionary<int, decimal> _initialMoney;
        private Dictionary<int, int> _initialDeeds;
        private int _minPlayers;
        private int _maxPlayers;
        private Dictionary<string, Image> _markers;
        private string _currency;
        private ResourceManager _resources;

        public DefaultConfigLoader()
        {
            _cells = new List<Casella>();
            _cards = new List<Carta>();
            _resources = Monopoli.Properties.Resources.ResourceManager;
        }

        #region Builder
        public virtual void Load()
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(Properties.Resources.config);
            LoadSettings(document);
            LoadCells(document);
            LoadCards(document);
            CreatePlayBoard();
        }

        protected virtual void LoadSettings(XmlDocument document)
        {
            XmlNodeList nodes = document.GetElementsByTagName("MinPlayers");
            _minPlayers = Int32.Parse(nodes.Item(0).InnerText);
            nodes = document.GetElementsByTagName("MaxPlayers");
            _maxPlayers = Int32.Parse(nodes.Item(0).InnerText);
            nodes = document.GetElementsByTagName("Cell");
            _cellNum = nodes.Count;
            nodes = document.GetElementsByTagName("CurrencySymbol");
            _currency = nodes.Item(0).InnerText;
            _initialMoney = new Dictionary<int, decimal>();
            nodes = document.GetElementsByTagName("InitialMoney");
            foreach (XmlNode node in nodes[0].ChildNodes)
            {
                _initialMoney.Add(Int32.Parse(node.Attributes["playersNum"].Value), Decimal.Parse(node.InnerText));
            }
            _initialDeeds = new Dictionary<int, int>();
            nodes = document.GetElementsByTagName("InitialDeeds");
            foreach (XmlNode node in nodes[0].ChildNodes)
            {
                _initialDeeds.Add(Int32.Parse(node.Attributes["playersNum"].Value), Int32.Parse(node.InnerText));
            }
            nodes = document.GetElementsByTagName("Markers");
            _markers = new Dictionary<string, Image>();
            foreach (XmlNode node in nodes[0].ChildNodes)
            {
                _markers.Add(node.InnerText, (Image)_resources.GetObject(node.InnerText));
            }
        }

        protected virtual void LoadCells(XmlDocument document) 
        {
            XmlNodeList nodes = document.GetElementsByTagName("Cell");
            foreach(XmlNode node in nodes)
            {
                LoadCell(node);
            }
        }

        protected virtual void LoadCards(XmlDocument document)
        {
            XmlNodeList nodes = document.GetElementsByTagName("Card");
            foreach (XmlNode node in nodes)
            {
                LoadCard(node);
            }
        }

        protected virtual void LoadCell(XmlNode node)
        {
            List<object> args = new List<object>();
            string model = node.Attributes["model"].Value;
            string cellType = node.Attributes["type"].Value;
            string groupName = null, name = null;
            decimal value = -1, sellValue = -1, houseCost = -1;
            List<decimal> rentValues = new List<decimal>();
            Image image = null;
            args.Add(Int32.Parse(node.Attributes["position"].Value));
            XmlNodeList data = node.ChildNodes;
            foreach (XmlNode n in data)
            {
                switch (n.Name)
                {
                    case "Name":
                        name = n.InnerText;
                        break;
                    case "Group":
                        groupName = n.InnerText;
                        break;
                    case "Value":
                        value = Decimal.Parse(n.InnerText);
                        break;
                    case "SellValue":
                        sellValue = Decimal.Parse(n.InnerText);
                        break;
                    case "HouseCost":
                        houseCost = Decimal.Parse(n.InnerText);
                        break;
                    case "Rent":
                        rentValues.Add(Decimal.Parse(n.InnerText));
                        break;
                    case "Image":
                        image = (Image)_resources.GetObject(n.InnerText);
                        break;
                    default:
                        throw new Exception("Invalid Field in a Cell Subtree! Check XML");
                }
            }
            args.AddRange(CellValidArguments(name, cellType, value, sellValue, rentValues, groupName, houseCost, image));
            Type type = Type.GetType("Monopoli.Model." + model);
            Casella cell = (Casella)Activator.CreateInstance(type, args.ToArray());
            _cells.Add(cell);
        }

        protected virtual IEnumerable<object> CellValidArguments(string name, string cellType, decimal value,
            decimal sellValue, List<decimal> rentValues, string groupName, decimal houseCost, Image image)
        {
            List<object> result = new List<object>();
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(cellType))
            {
                result.Add(name);
                result.Add(cellType);
            }
            if (value >= 0)
            {
                result.Add(value);
            }
            if (sellValue >= 0)
            {
                result.Add(sellValue);
            }
            if (rentValues != null && rentValues.Count > 0)
            {
                result.Add(rentValues.ToArray());
            }
            if (!String.IsNullOrEmpty(groupName))
            {
                result.Add(groupName);
            }
            if (houseCost >= 0)
            {
                result.Add(houseCost);
            }
            if (image != null)
            {
                result.Add(image);
            }
            return result;
        }

        protected virtual void LoadCard(XmlNode node)
        {
            List<object> args = new List<object>();
            string cardType = node.Attributes["type"].Value;
            string model = node.Attributes["action"].Value;
            string instruction = null, destination = null;
            decimal value = -1, houseValue = -1, hotelValue = -1;
            XmlNodeList data = node.ChildNodes;
            foreach (XmlNode n in data)
            {
                switch (n.Name)
                {
                    case "Instruction":
                        instruction = n.InnerText;
                        break;
                    case "Value":
                        value = Decimal.Parse(n.InnerText);
                        break;
                    case "HouseValue":
                        houseValue = Decimal.Parse(n.InnerText);
                        break;
                    case "HotelValue":
                        hotelValue = Decimal.Parse(n.InnerText);
                        break;
                    case "Destination":
                        destination = n.InnerText;
                        break;
                    default:
                        throw new Exception("Invalid Field in a Card Subtree! Check XML");
                }
            }
            if (cardType == "Probabilità")
            {
                args.Add(Carta.TipoCarta.PROBABILITA);
            }
            else
            {
                args.Add(Carta.TipoCarta.IMPREVISTI);
            }
            Type type = Type.GetType("Monopoli.Model.Carta+" + model);
            args.AddRange(CardValidArguments(instruction, value, houseValue, hotelValue, destination));
            Carta card = (Carta)Activator.CreateInstance(type, args.ToArray());
            _cards.Add(card);
        }

        protected virtual IEnumerable<object> CardValidArguments(string instruction, decimal value,
            decimal houseValue, decimal hotelValue, string destination)
        {
            List<object> result = new List<object>();
            if (!String.IsNullOrEmpty(instruction))
            {
                result.Add(instruction);
            }
            if (value >= 0)
            {
                result.Add(value);
            }
            if (houseValue >= 0 && hotelValue >= 0)
            {
                result.Add(houseValue);
                result.Add(hotelValue);
            }
            if (!String.IsNullOrEmpty(destination))
            {
                result.Add(destination);
            }
            return result;
        }

        protected virtual void CreatePlayBoard()
        {
            List<Carta> chance = new List<Carta>();
            foreach (Carta card in _cards)
            {
                if (card.Tipo == Carta.TipoCarta.IMPREVISTI)
                {
                    chance.Add(card);
                }
            }
            List<Carta> communityChest = new List<Carta>();
            foreach (Carta card in _cards)
            {
                if (card.Tipo == Carta.TipoCarta.PROBABILITA)
                {
                    communityChest.Add(card);
                }
            }
            _playBoard = new TavolaDaGioco(_cells.ToArray(), chance.ToArray(), communityChest.ToArray());
        }
        #endregion

        #region Results
        public virtual IEnumerable<object> GetCells()
        {
            return _cells.ToArray();
        }

        public virtual IEnumerable<object> GetCards()
        {
            return _cards.ToArray();
        }

        public virtual object GetPlayBoard()
        {
            return _playBoard;
        }

        public virtual int GetPlayerMinNum()
        {
            return _minPlayers;
        }

        public virtual int GetPlayerMaxNum()
        {
            return _maxPlayers;
        }

        public virtual int GetNumCells()
        {
            return _cellNum;
        }

        public virtual string GetCurrencySymbol()
        {
            return _currency;
        }

        public virtual Dictionary<int, decimal> GetInitialMoneyValues()
        {
            return _initialMoney;
        }

        public virtual Dictionary<int, int> GetinitialDeeds()
        {
            return _initialDeeds;
        }

        public virtual Dictionary<string, Image> GetMarkers()
        {
            return _markers;
        }
        #endregion
    }
}
