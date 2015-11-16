//      *********    NE PAS MODIFIER CE FICHIER     *********
//      Ce fichier est régénéré par un outil de création.Modifier
// .     ce fichier peut provoquer des erreurs.
namespace Expression.Blend.SampleData.SNAP_DATA
{
	using System; 
	using System.ComponentModel;

// Pour réduire de façon significative le volume des exemples de données dans votre application de production, vous pouvez définir
// la constante de compilation conditionnelle DISABLE_SAMPLE_DATA et désactiver les données échantillons lors de l'exécution.
#if DISABLE_SAMPLE_DATA
	internal class SNAP_DATA { }
#else

	public class SNAP_DATA : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public SNAP_DATA()
		{
			try
			{
				Uri resourceUri = new Uri("/SNAP;component/SampleData/SNAP_DATA/SNAP_DATA.xaml", UriKind.RelativeOrAbsolute);
				System.Windows.Application.LoadComponent(this, resourceUri);
			}
			catch
			{
			}
		}

		private Joueurs _Joueurs = new Joueurs();

		public Joueurs Joueurs
		{
			get
			{
				return this._Joueurs;
			}
		}

		private résultats _résultats = new résultats();

		public résultats résultats
		{
			get
			{
				return this._résultats;
			}
		}
	}

	public class JoueursItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private string _Nom = string.Empty;

		public string Nom
		{
			get
			{
				return this._Nom;
			}

			set
			{
				if (this._Nom != value)
				{
					this._Nom = value;
					this.OnPropertyChanged("Nom");
				}
			}
		}

		private string _Surnom = string.Empty;

		public string Surnom
		{
			get
			{
				return this._Surnom;
			}

			set
			{
				if (this._Surnom != value)
				{
					this._Surnom = value;
					this.OnPropertyChanged("Surnom");
				}
			}
		}

		private string _Arme_primaire = string.Empty;

		public string Arme_primaire
		{
			get
			{
				return this._Arme_primaire;
			}

			set
			{
				if (this._Arme_primaire != value)
				{
					this._Arme_primaire = value;
					this.OnPropertyChanged("Arme_primaire");
				}
			}
		}
	}

	public class Joueurs : System.Collections.ObjectModel.ObservableCollection<JoueursItem>
	{ 
	}

	public class résultatsItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private string _participation = string.Empty;

		public string participation
		{
			get
			{
				return this._participation;
			}

			set
			{
				if (this._participation != value)
				{
					this._participation = value;
					this.OnPropertyChanged("participation");
				}
			}
		}
	}

	public class résultats : System.Collections.ObjectModel.ObservableCollection<résultatsItem>
	{ 
	}
#endif
}
