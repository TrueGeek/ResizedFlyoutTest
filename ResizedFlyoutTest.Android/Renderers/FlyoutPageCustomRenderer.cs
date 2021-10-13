using System;
using Android.Content;
using Android.Views;
using ResizedFlyoutTest.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FlyoutPage), typeof(FlyoutPageCustomRenderer))]
namespace ResizedFlyoutTest.Droid.Renderers
{

    public class FlyoutPageCustomRenderer : FlyoutPageRenderer
    {

        public FlyoutPageCustomRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(VisualElement oldElement, VisualElement newElement)
        {

            SetFlyoutAndDetailWidths();

            base.OnElementChanged(oldElement, newElement);

        }

        private void SetFlyoutAndDetailWidths()
        {

            // set flyout width
            var fieldInfo = GetType().BaseType.GetField("_flyoutLayout", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            var _flyoutLayout = (ViewGroup)fieldInfo.GetValue(this);
            _flyoutLayout.LayoutParameters = new LayoutParams(_flyoutLayout.LayoutParameters)
            {
                Width = 512,        // default is 320
                Height = 528,
            };

            // set detail width
            //var fieldInfo2 = GetType().BaseType.GetField("_detailLayout", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //var _detailLayout = (ViewGroup)fieldInfo2.GetValue(this);
            //_detailLayout.LayoutParameters = new LayoutParams(_detailLayout.LayoutParameters)
            //{
            //    Width = 512,       // default is 704
            //    Height = 528,
            //};

        }

    }

}
