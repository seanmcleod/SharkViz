using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Media;

namespace SharkViz
{
	public class SharkViewModel : INotifyPropertyChanged
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

		private ObservableCollection<Edge> _edges;

		public ObservableCollection<Edge> Edges
		{
			get { return _edges; }
			set
			{
				_edges = value;
				OnPropertyChanged("Edges");
			}
		}

		public SharkViewModel()
		{
			// TODO Get from data file in future
			_listeningStations = new ObservableCollection<ListeningStation>();

			_listeningStations.Add(new ListeningStation() { ID = "SIS", Name = "Seal Island", Location = new Location(-34.14258333, 18.58165), Value = 100 });
			_listeningStations.Add(new ListeningStation() { ID = "SIN", Name = "Seal Island", Location = new Location(-34.1327, 18.58141667), Value = 79 });
			_listeningStations.Add(new ListeningStation() { ID = "MO", Name = "Macassar", Location = new Location(-34.09341667, 18.73695), Value = 50 });
			_listeningStations.Add(new ListeningStation() { ID = "MI", Name = "Macassar", Location = new Location(-34.08625, 18.73991667), Value = 50 });
			_listeningStations.Add(new ListeningStation() { ID = "SF01", Name = "Strandfontein", Location = new Location(-34.1156, 18.56886667), Value = 59 });
			_listeningStations.Add(new ListeningStation() { ID = "SF2", Name = "Strandfontein", Location = new Location(-34.10911667, 18.56393333), Value = 39 });
			_listeningStations.Add(new ListeningStation() { ID = "SF3", Name = "Strandfontein", Location = new Location(-34.10346667, 18.5597), Value = 19 });
			_listeningStations.Add(new ListeningStation() { ID = "STO", Name = "SimonsTown", Location = new Location(-34.18051667, 18.44601667), Value = 50 });
			_listeningStations.Add(new ListeningStation() { ID = "KBO", Name = "Koeel Bay", Location = new Location(-34.22796667, 18.8228), Value = 50 });
			_listeningStations.Add(new ListeningStation() { ID = "MBC", Name = "Muizenberg", Location = new Location(-34.1195, 18.46888333), Value = 50 });
			_listeningStations.Add(new ListeningStation() { ID = "GBO", Name = "Gordons Bay", Location = new Location(-34.15681667, 18.84028333), Value = 50 });
			_listeningStations.Add(new ListeningStation() { ID = "RKI", Name = "Cape Point", Location = new Location(-34.3426, 18.48141667), Value = 50 });

			// Edges
			_edges = new ObservableCollection<Edge>();

			// SIS - Muizenberg
			_edges.Add(new Edge(_listeningStations[0], _listeningStations[9], 79));
			// Simonstown - Muizenberg
			_edges.Add(new Edge(_listeningStations[7], _listeningStations[9], 100));
			// Muizenberg - SF3
			_edges.Add(new Edge(_listeningStations[9], _listeningStations[6], 19));
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (propertyName != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}