using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Resources;

namespace Monopoli.Controller
{
    class DefaultConfigLoader : IConfigLoader
    {
        private XmlDocument _document;
        private List<CellValue> _cells;
        private List<CardValue> _cards;
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
            _document = new XmlDocument();
            _cells = new List<CellValue>();
            _cards = new List<CardValue>();
            _resources = Monopoli.Properties.Resources.ResourceManager;
        }

        public virtual void Load()
        {
            _document.LoadXml(Properties.Resources.config);
            LoadSettings();
            LoadCells();
            LoadCards();
        }

        protected virtual void LoadSettings()
        {
            XmlNodeList nodes = _document.GetElementsByTagName("MinPlayers");
            _minPlayers = Int32.Parse(nodes.Item(0).InnerText);
            nodes = _document.GetElementsByTagName("MaxPlayers");
            _maxPlayers = Int32.Parse(nodes.Item(0).InnerText);
            nodes = _document.GetElementsByTagName("Cell");
            _cellNum = nodes.Count;
            nodes = _document.GetElementsByTagName("CurrencySymbol");
            _currency = nodes.Item(0).InnerText;
            _initialMoney = new Dictionary<int, decimal>();
            nodes = _document.GetElementsByTagName("InitialMoney");
            foreach (XmlNode node in nodes[0].ChildNodes)
            {
                _initialMoney.Add(Int32.Parse(node.Attributes["playersNum"].Value), Decimal.Parse(node.InnerText));
            }
            _initialDeeds = new Dictionary<int, int>();
            nodes = _document.GetElementsByTagName("InitialDeeds");
            foreach (XmlNode node in nodes[0].ChildNodes)
            {
                _initialDeeds.Add(Int32.Parse(node.Attributes["playersNum"].Value), Int32.Parse(node.InnerText));
            }
            nodes = _document.GetElementsByTagName("Markers");
            _markers = new Dictionary<string, Image>();
            foreach (XmlNode node in nodes[0].ChildNodes)
            {
                _markers.Add(node.InnerText, (Image)_resources.GetObject(node.InnerText));
            }
        }

        protected virtual void LoadCells() 
        {
            XmlNodeList nodes = _document.GetElementsByTagName("Cell");
            foreach(XmlNode node in nodes)
            {
                LoadCell(node);
            }
        }

        protected virtual void LoadCards()
        {
            XmlNodeList nodes = _document.GetElementsByTagName("Card");
            foreach (XmlNode node in nodes)
            {
                LoadCard(node);
            }
        }

        public virtual object[] GetCells()
        {
            return _cells.ToArray();
        }

        public virtual object[] GetCards()
        {
            return _cards.ToArray();
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

        protected virtual void LoadCell(XmlNode node)
        {
            CellValue cell = new CellValue();
            cell.Model = node.Attributes["model"].Value;
            cell.Id = Int32.Parse(node.Attributes["position"].Value);
            cell.Type = node.Attributes["type"].Value;
            XmlNodeList data = node.ChildNodes;
            foreach (XmlNode n in data)
            {
                switch (n.Name)
                {
                    case "Name":
                        cell.Name = n.InnerText;
                        break;
                    case "Group":
                        cell.GroupName = n.InnerText;
                        break;
                    case "Value":
                        cell.Value = Decimal.Parse(n.InnerText);
                        break;
                    case "SellValue":
                        cell.SellValue = Decimal.Parse(n.InnerText);
                        break;
                    case "HouseCost":
                        cell.HouseCost = Decimal.Parse(n.InnerText);
                        break;
                    case "Rent":
                        cell.AddRentValue(Decimal.Parse(n.InnerText));
                        break;
                    case "Image":
                        cell.Image = (Image)_resources.GetObject(n.InnerText);
                        break;
                    default:
                        throw new Exception("Invalid Field in a Cell Subtree! Check XML");
                }
            }
            _cells.Add(cell);
        }

        protected virtual void LoadCard(XmlNode node)
        {
            CardValue card = new CardValue();
            card.Type = node.Attributes["type"].Value;
            card.Action = node.Attributes["action"].Value;
            XmlNodeList data = node.ChildNodes;
            foreach (XmlNode n in data)
            {
                switch (n.Name)
                {
                    case "Instruction":
                        card.Instruction = n.InnerText;
                        break;
                    case "Value":
                        card.Value = Decimal.Parse(n.InnerText);
                        break;
                    case "HouseValue":
                        card.HouseValue = Decimal.Parse(n.InnerText);
                        break;
                    case "HotelValue":
                        card.HotelValue = Decimal.Parse(n.InnerText);
                        break;
                    case "Destination":
                        card.Destination = n.InnerText;
                        break;
                    default:
                        throw new Exception("Invalid Field in a Card Subtree! Check XML");
                }
            }
            _cards.Add(card);
        }

        internal class CellValue
        {
            int _id = -1;
            string _name = null;
            decimal _value = -1;
            decimal _sellValue = -1;
            decimal _houseCost = -1;
            string _groupName = null;
            List<decimal> _rentValues = new List<decimal>();
            string _model = null;
            string _type = null;
            Image _image = null;

            public string Model
            {
                get { return _model; }
                set { _model = value; }
            }

            public string GroupName
            {
                get { return _groupName; }
                set { _groupName = value; }
            }

            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }

            public decimal Value
            {
                get { return _value; }
                set { _value = value; }
            }

            public decimal SellValue
            {
                get { return _sellValue; }
                set { _sellValue = value; }
            }

            public decimal HouseCost
            {
                get { return _houseCost; }
                set { _houseCost = value; }
            }

            public void AddRentValue(decimal value)
            {
                _rentValues.Add(value);
            }

            public List<decimal> RentValues
            {
                get { return _rentValues; }
                set { _rentValues = value; }
            }

            public Image Image
            {
                get { return _image; }
                set { _image = value; }
            }
            
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }

            public string Type
            {
                get { return _type; }
                set { _type = value; }
            }

            public object[] ToModelArguments()
            {
                List<object> result = new List<object>();
                if (_id < 0 || _name == null || _model == null)
                {
                    return null;
                }
                result.Add(_id);
                result.Add(_name);
                if (_value >= 0)
                {
                    result.Add(_value);
                }
                else { return result.ToArray(); }
                if (_sellValue >= 0)
                {
                    result.Add(_sellValue);
                } else { return result.ToArray(); }
                if (_rentValues.Count > 0)
                {
                    result.Add(_rentValues.ToArray());
                }
                if (_groupName != null)
                {
                    result.Add(_groupName);
                }
                if (_houseCost >= 0)
                {
                    result.Add(_houseCost);
                }
                return result.ToArray();
            }

            public object[] ToViewArguments()
            {
                List<object> result = new List<object>();
                if (_name == null || _id < 0)
                {
                    return null;
                }
                result.Add(_name);
                if (_value >= 0)
                {
                    result.Add(_value);
                }
                if (_groupName != null)
                {
                    result.Add(_groupName);
                }
                if (_image != null)
                {
                    result.Add(_image);
                }
                return result.ToArray();
            }

            public List<object> ToDeedArguments()
            {
                List<object> result = new List<object>();
                if (_id < 0 || _name == null || _value < 0 || _sellValue < 0 || _rentValues.Count == 0 || _groupName == null)
                {
                    return null;
                }
                result.Add(_id);
                result.Add(_name);
                result.Add(_value);
                result.Add(_sellValue);
                result.Add(_rentValues.ToArray());
                result.Add(_groupName);
                if (_image != null)
                {
                    result.Add(_image);
                    return result;
                }
                if (_houseCost >= 0)
                {
                    result.Add(_houseCost);
                }
                return result;
            }
        }

        internal class CardValue
        {
            string _type = null;
            string _instruction = null;
            string _action = null;
            decimal _value = -1;
            decimal _houseValue = -1;
            decimal _hotelValue = -1;
            string _destination = null;

            public string Type
            {
                get { return _type; }
                set { _type = value; }
            }

            public string Instruction
            {
                get { return _instruction; }
                set { _instruction = value; }
            }

            public string Action
            {
                get { return _action; }
                set { _action = value; }
            }

            public decimal Value
            {
                get { return _value; }
                set { _value = value; }
            }

            public decimal HouseValue
            {
                get { return _houseValue; }
                set { _houseValue = value; }
            }

            public decimal HotelValue
            {
                get { return _hotelValue; }
                set { _hotelValue = value; }
            }

            public string Destination
            {
                get { return _destination; }
                set { _destination = value; }
            }

            public object[] ToModelArguments()
            {
                List<object> result = new List<object>();
                if (_type == null || _instruction == null || _action == null)
                {
                    return null;
                }
                result.Add(_instruction);
                if (_value >= 0)
                {
                    result.Add(_value);
                    return result.ToArray();
                }
                if (_houseValue >= 0 && _hotelValue >= 0)
                {
                    result.Add(_houseValue);
                    result.Add(_hotelValue);
                    return result.ToArray();
                }
                if (_destination != null)
                {
                    result.Add(_destination);
                }
                return result.ToArray();
            }
        }
    }
}
