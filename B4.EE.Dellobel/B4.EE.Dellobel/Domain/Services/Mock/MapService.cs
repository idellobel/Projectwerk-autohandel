using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace B4.EE.DellobelI.Domain.Services.Mock
{
    public class MapService : Map
    {
        public static readonly BindableProperty MapPinsProperty = BindableProperty.Create(
        nameof(Pins),
        typeof(ObservableCollection<Pin>),
        typeof(MapService),
        new ObservableCollection<Pin>(),
        propertyChanged: (b, o, n) =>
        {
            var bindable = (MapService)b;
            bindable.Pins.Clear();

            var collection = (ObservableCollection<Pin>)n;
            foreach (var item in collection)
                bindable.Pins.Add(item);

            collection.CollectionChanged += (sender, e) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    switch (e.Action)
                    {
                        case NotifyCollectionChangedAction.Add:
                        case NotifyCollectionChangedAction.Replace:
                        case NotifyCollectionChangedAction.Remove:
                            if (e.OldItems != null)
                                foreach (var item in e.OldItems)
                                    bindable.Pins.Remove((Pin)item);

                            if (e.NewItems != null)
                                foreach (var item in e.NewItems)
                                    bindable.Pins.Add((Pin)item);
                            break;
                        case NotifyCollectionChangedAction.Reset:
                            bindable.Pins.Clear();
                            break;
                    }
                });
            };
        });

        public IList<Pin> MapPins { get; set; }

        public static readonly BindableProperty MapPositionProperty = BindableProperty.Create(
                nameof(MapPosition),
                typeof(Position),
                typeof(MapService),
                new Position(0, 0),
                propertyChanged: (b, o, n) =>
                {
                    ((MapService)b).MoveToRegion(MapSpan.FromCenterAndRadius(
                                (Position)n, Distance.FromMiles(1)));

                });
        public Position MapPosition { get; set; }
    }
}
