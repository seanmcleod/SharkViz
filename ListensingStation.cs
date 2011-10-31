using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;

namespace SharkViz
{
	public class ListeningStation
	{
		public string ID { get; set; }
		public string Name { get; set; }
		public Location Location { get; set; }

		public double Value { get; set; }
	}

	public class ListeningStationViewModel : INotifyPropertyChanged
	{
		private ObservableCollection<ListeningStation> _listeningStations;

		public ObservableCollection<ListeningStation> ListeningStations
		{
			get { return _listeningStations; }
			set
			{
				_listeningStations = value;
				OnPropertyChanged("ListeningStations");
			}
		}

		public ListeningStationViewModel()
		{
			// TODO Get from data file in future
			_listeningStations = new ObservableCollection<ListeningStation>();

			_listeningStations.Add(new ListeningStation() { ID = "SIS",		Name = "Seal Island",	Location = new Location(-34.14258333, 18.58165) });
			_listeningStations.Add(new ListeningStation() { ID = "SIN",		Name = "Seal Island",	Location = new Location(-34.1327, 18.58141667) });
			_listeningStations.Add(new ListeningStation() { ID = "MO",		Name = "Macassar",		Location = new Location(-34.09341667, 18.73695) });
			_listeningStations.Add(new ListeningStation() { ID = "MI",		Name = "Macassar",		Location = new Location(-34.08625, 18.73991667) });
			_listeningStations.Add(new ListeningStation() { ID = "SF01",	Name = "Strandfontein",	Location = new Location(-34.1156, 18.56886667) });
			_listeningStations.Add(new ListeningStation() { ID = "SF2",		Name = "Strandfontein", Location = new Location(-34.10911667, 18.56393333) });
			_listeningStations.Add(new ListeningStation() { ID = "SF3",		Name = "Strandfontein", Location = new Location(-34.10346667, 18.5597) });
			_listeningStations.Add(new ListeningStation() { ID = "STO",		Name = "SimonsTown",	Location = new Location(-34.18051667, 18.44601667) });
			_listeningStations.Add(new ListeningStation() { ID = "KBO",		Name = "Koeel Bay",		Location = new Location(-34.22796667, 18.8228) });
			_listeningStations.Add(new ListeningStation() { ID = "MBC",		Name = "Muizenberg",	Location = new Location(-34.1195, 18.46888333) });
			_listeningStations.Add(new ListeningStation() { ID = "GBO",		Name = "Gordons Bay",	Location = new Location(-34.15681667, 18.84028333) });
			_listeningStations.Add(new ListeningStation() { ID = "RKI",		Name = "Cape Point",	Location = new Location(-34.3426, 18.48141667) });
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (propertyName != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}