using UnityEngine;

namespace Dots.Utils
{
    /// <summary>
    ///     Class responsible for displaying lines between selected dots and touch.
    /// </summary>
    public class LinePainter : Singleton<LinePainter>
    {
        // We use 2 because 1 will cause problems when rendering line over the last one
        [SerializeField]  LineRenderer _lineRendererTouch;
        [SerializeField]  LineRenderer _lineRendererGroup;

         bool _startPainting;
         Vector3 _touchPosition;

        protected virtual void Start()
        {
            _startPainting = false;
        }

        protected virtual void Update()
        {
            if (!_startPainting)
            {
                return;
            }

            // Touch position is going to be the last position on Touch Line Renderer
            _touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _lineRendererTouch.SetPosition(_lineRendererTouch.positionCount - 1,
                new Vector3(_touchPosition.x, _touchPosition.y, 0));
        }

        /// <summary>
        ///     Initializes the LineRenderers and boolean to start rendering.
        /// </summary>
         void StartPainting()
        {
            _startPainting = true;
            _lineRendererTouch.positionCount = 2;
            _lineRendererGroup.positionCount = 0;
        }

        /// <summary>
        ///     Stops the painting and resets the renderers.
        /// </summary>
        public void StopPainting()
        {
            _startPainting = false;
            _lineRendererTouch.positionCount = 0;
            _lineRendererGroup.positionCount = 0;
        }

        /// <summary>
        ///     Adds a position to existing LineRenderers.
        /// </summary>
        /// <param name="position">The position to add.</param>
        public void AddPosition(Vector3 position)
        {
            if (_startPainting == false)
            {
                StartPainting();
            }

            _lineRendererGroup.positionCount++; // The group always add 1 position
            _lineRendererGroup.SetPosition(_lineRendererGroup.positionCount - 1, position);
            // Sets it as it's last position
            _lineRendererTouch.SetPosition(0, position);
            // The Touch renderer makes the newly added position as it's first
        }

        /// <summary>
        ///     Sets the color.
        ///     Default will be the material color which is Black.
        /// </summary>
        /// <param name="lineColor">Color of the line.</param>
        public void SetColor(Color lineColor)
        {
            _lineRendererTouch.material.color = lineColor;
            _lineRendererGroup.material.color = lineColor;
        }

        /// <summary>
        ///     Removes the last position added.
        /// </summary>
        public void RemoveLastPosition()
        {
            _lineRendererGroup.positionCount--;
            _lineRendererTouch.SetPosition(0, _lineRendererGroup.GetPosition(_lineRendererGroup.positionCount - 1));
        }
    }
}
