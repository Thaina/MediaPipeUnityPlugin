// Copyright (c) 2023 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

using UnityEngine;

using Mediapipe.Tasks.Vision.PoseLandmarker;

namespace Mediapipe.Unity
{
  public class PoseLandmarkerResultAnnotationController : AnnotationController<MultiPoseLandmarkListAnnotation>
  {
    [SerializeField] private bool _visualizeZ = false;

    private PoseLandmarkerResult _currentTarget;

    public void DrawNow(PoseLandmarkerResult target)
    {
      _currentTarget = target;
      SyncNow();
    }

    public void DrawLater(PoseLandmarkerResult target) => UpdateCurrentTarget(target, ref _currentTarget);

    protected override void SyncNow()
    {
      isStale = false;
      if (_currentTarget.poseLandmarks.Count > 0)
      {
        annotation.Draw(_currentTarget.poseLandmarks, _visualizeZ);
      }
    }
  }
}
