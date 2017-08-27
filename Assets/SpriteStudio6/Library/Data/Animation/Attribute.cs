/**
	SpriteStudio6 Player for Unity

	Copyright(C) Web Technology Corp. 
	All rights reserved.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Library_SpriteStudio6
{
	public static partial class Data
	{
		public partial class Animation
		{
			public static partial class Attribute
			{
				/* ----------------------------------------------- Enums & Constants */
				#region Enums & Constants
				/* Default values when no Key-Data exists */
				public const bool DefaultFlipX = false;
				public const bool DefaultFlipY = false;
				public const bool DefaultHide = false;
				public readonly static Status DefaultStatus = new Status(Status.FlagBit.CLEAR);

				public readonly static Cell DefaultCell = new Cell(-1, -1);

				public const float DefaultPositionX = 0.0f;
				public const float DefaultPositionY = 0.0f;
				public const float DefaultPositionZ = 0.0f;
				public readonly static Vector3 DefaultPosition = Vector3.zero;
				public const float DefaultRotationX = 0.0f;
				public const float DefaultRotationY = 0.0f;
				public const float DefaultRotationZ = 0.0f;
				public readonly static Vector3 DefaultRotation = Vector3.zero;
				public const float DefaultScalingX = 1.0f;
				public const float DefaultScalingY = 1.0f;
				public const float DefaultScalingZ = 1.0f;
				public readonly static Vector2 DefaultScaling = Vector2.one;

				public const float DefaultRateOpacity = 1.0f;
				public const float DefaultPriority = 0.0f;

				private readonly static Vector2[] TableCoordinateVertexCorrectionDefault = new Vector2[(int)Library_SpriteStudio6.KindVertex.TERMINATOR2]
				{
					Vector2.zero,
					Vector2.zero,
					Vector2.zero,
					Vector2.zero,
				};
				public readonly static VertexCorrection DefaultVertexCorrection = new VertexCorrection(TableCoordinateVertexCorrectionDefault);
				private readonly static Color[] TableVertexColorColorBlendDefault = new Color[(int)Library_SpriteStudio6.KindVertex.TERMINATOR2]
				{
					Color.white,
					Color.white,
					Color.white,
					Color.white
				};
				private readonly static float[] TableRatePixelAlphaColorBlendDefault = new float[(int)Library_SpriteStudio6.KindVertex.TERMINATOR2]
				{
					1.0f,
					1.0f,
					1.0f,
					1.0f
				};
				public readonly static ColorBlend DefaultColorBlend = new ColorBlend(	Library_SpriteStudio6.KindBoundBlend.NON,
																						Library_SpriteStudio6.KindOperationBlend.MIX,
																						TableVertexColorColorBlendDefault,
																						TableRatePixelAlphaColorBlendDefault
																					);

				public const float DefaultPivotOffsetX = 0.0f;
				public const float DefaultPivotOffsetY = 0.0f;
				public readonly static Vector2 DefaultPivotOffset = Vector2.zero;

				public const float DefaultAnchorPositionX = 0.0f;
				public const float DefaultAnchorPositionY = 0.0f;
				public readonly static Vector2 DefaultAnchorPoint = Vector2.zero;

				public const float DefaultSizeForceX = 1.0f;
				public const float DefaultSizeForceY = 1.0f;
				public readonly static Vector2 DefaultSizeForce = Vector2.one;

				public const float DefaultTexturePositionX = 0.0f;
				public const float DefaultTexturePositionY = 0.0f;
				public readonly static Vector2 DefaultTexturePosition = Vector2.zero;

				public const float DefaultTextureRotation = 0.0f;
				public const float DefaultTextureScalingX = 1.0f;
				public const float DefaultTextureScalingY = 1.0f;
				public readonly static Vector2 DefaultTextureScaling = Vector2.one;
				public const bool DefaultTextureFlipX = false;
				public const bool DefaultTextureFlipY = false;

				public const float DefaultCollisionRadius = 0.0f;

				public readonly static UserData DefaultUseData = new UserData(UserData.FlagBit.CLEAR, 0, Rect.zero, Vector2.zero, "");

				public readonly static Instance DefaultInstance = new Instance(Instance.FlagBit.CLEAR, 0, 1.0f, 0, 0, "", "");

				public readonly static Effect DefaultEffect = new Effect(Effect.FlagBit.CLEAR, 0, 1.0f);

				#endregion Enums & Constants

				/* ----------------------------------------------- Classes, Structs & Interfaces */
				#region Classes, Structs & Interfaces
				[System.Serializable]
				public struct Status
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public FlagBit Flags;

					public bool IsValid
					{
						get
						{
							return(0 != (Flags & FlagBit.VALID));
						}
					}
					public bool IsHide
					{
						get
						{
							return(0 != (Flags & FlagBit.HIDE));
						}
					}
					public bool IsFlipX
					{
						get
						{
							return(0 != (Flags & FlagBit.FLIPX));
						}
					}
					public bool IsFlipY
					{
						get
						{
							return(0 != (Flags & FlagBit.FLIPY));
						}
					}
					public bool IsTextureFlipX
					{
						get
						{
							return(0 != (Flags & FlagBit.FLIPXTEXTURE));
						}
					}
					public bool IsTextureFlipY
					{
						get
						{
							return(0 != (Flags & FlagBit.FLIPYTEXTURE));
						}
					}
					public int PartsIDNext
					{
						get
						{
							FlagBit data = Flags & FlagBit.PARTSIDNEXT;
							return((0 == data) ? (-1) : (int)data);
						}
					}
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public Status(FlagBit flags)
					{
						Flags = flags;
					}

					public void CleanUp()
					{
						Flags = FlagBit.CLEAR;
					}

					public void Duplicate(Status original)
					{
						Flags = original.Flags;
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						Status targetData = (Status)target;
						return((Flags & FlagBit.MASK) == (targetData.Flags & FlagBit.MASK));
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions

					/* ----------------------------------------------- Enums & Constants */
					#region Enums & Constants
					[System.Flags]
					public enum FlagBit
					{
						VALID = 0x40000000,
						HIDE = 0x20000000,

						FLIPX = 0x08000000,
						FLIPY = 0x04000000,
						FLIPXTEXTURE = 0x02000000,
						FLIPYTEXTURE = 0x01000000,

						PARTSIDNEXT = 0x0000ffff,

						CLEAR = 0x00000000,
						MASK = (VALID | HIDE | FLIPX | FLIPY | FLIPXTEXTURE | FLIPYTEXTURE | PARTSIDNEXT),
					}
					#endregion Enums & Constants
				}

				[System.Serializable]
				public struct Cell
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public int IndexCellMap;
					public int IndexCell;
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public Cell(int indexCellMap, int indexCell)
					{
						IndexCellMap = indexCellMap;
						IndexCell = indexCell;
					}

					public void CleanUp()
					{
						IndexCellMap = -1;
						IndexCell = -1;
					}

					public void Duplicate(Cell original)
					{
						IndexCellMap = original.IndexCellMap;
						IndexCell = original.IndexCell;
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						Cell targetData = (Cell)target;
						return((IndexCellMap == targetData.IndexCellMap) && (IndexCell == targetData.IndexCell));
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions
				}

				[System.Serializable]
				public struct VertexCorrection
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public Vector2[] Coordinate;
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public VertexCorrection(Vector2[] coordinate)
					{
						Coordinate = coordinate;
					}

					public void CleanUp()
					{
						Coordinate = null;
					}

					public void Duplicate(VertexCorrection original)
					{
						for(int i=0; i<Coordinate.Length; i++)
						{
							Coordinate[i] = original.Coordinate[i];
						}
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						VertexCorrection targetData = (VertexCorrection)target;
						int count = Coordinate.Length;
						if(count != targetData.Coordinate.Length)
						{
							return(false);
						}
						for(int i=0; i<count; i++)
						{
							if(Coordinate[i] != targetData.Coordinate[i])
							{
								return(false);
							}
						}
						return(true);
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions
				}

				[System.Serializable]
				public struct ColorBlend
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public Library_SpriteStudio6.KindBoundBlend Bound;
					public Library_SpriteStudio6.KindOperationBlend Operation;
					public Color[] VertexColor;
					public float[] RatePixelAlpha;
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public ColorBlend(	Library_SpriteStudio6.KindBoundBlend bound,
										Library_SpriteStudio6.KindOperationBlend operation,
										Color[] vertexColor,
										float[] ratePixelAlpha
									)
					{
						Bound = bound;
						Operation = operation;
						VertexColor = vertexColor;
						RatePixelAlpha = ratePixelAlpha;
					}

					public void CleanUp()
					{
						Bound = Library_SpriteStudio6.KindBoundBlend.NON;
						Operation = Library_SpriteStudio6.KindOperationBlend.MIX;
						VertexColor = null;
						RatePixelAlpha = null;
					}

					public void Duplicate(ColorBlend original)
					{
						Bound = original.Bound;
						Operation = original.Operation;
						for(int i=0; i<(int)Library_SpriteStudio6.KindVertex.TERMINATOR2; i++)
						{
							VertexColor[i] = original.VertexColor[i];
							RatePixelAlpha[i] = original.RatePixelAlpha[i];
						}
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						ColorBlend targetData = (ColorBlend)target;

						if((Bound != targetData.Bound) || (Operation != targetData.Operation))
						{
							return(false);
						}
						if((VertexColor.Length != targetData.VertexColor.Length) || (RatePixelAlpha.Length != targetData.RatePixelAlpha.Length))
						{
							return(false);
						}
						for(int i=0; i<(int)Library_SpriteStudio6.KindVertex.TERMINATOR2; i++)
						{
							if((VertexColor[i] != targetData.VertexColor[i]) || (RatePixelAlpha[i] != targetData.RatePixelAlpha[i]))
							{
								return(false);
							}
						}
						return(true);
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions
				}

				[System.Serializable]
				public struct UserData
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public FlagBit Flags;
					public int NumberInt;
					public Rect Rectangle;
					public Vector2 Coordinate;
					public string Text;

					public bool IsValid
					{
						get
						{
							return(0 != (Flags & FlagBit.VALID));
						}
					}
					public bool IsNumber
					{
						get
						{
							return(0 != (Flags & FlagBit.NUMBER));
						}
					}
					public bool IsRectangle
					{
						get
						{
							return(0 != (Flags & FlagBit.RECTANGLE));
						}
					}
					public bool IsCoordinate
					{
						get
						{
							return(0 != (Flags & FlagBit.COORDINATE));
						}
					}
					public bool IsText
					{
						get
						{
							return(0 != (Flags & FlagBit.TEXT));
						}
					}
					public uint Number
					{
						get
						{
							return((uint)NumberInt);
						}
					}
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public UserData(FlagBit flags, int numberInt, Rect rectangle, Vector2 coordinate, string text)
					{
						Flags = flags;
						NumberInt = numberInt;
						Rectangle = rectangle;
						Coordinate = coordinate;
						Text = text;
					}

					public void CleanUp()
					{
						Flags = FlagBit.CLEAR;
						NumberInt = 0;
						Rectangle.xMin = 0.0f;
						Rectangle.yMin = 0.0f;
						Rectangle.xMax = 0.0f;
						Rectangle.yMax = 0.0f;
						Coordinate = Vector2.zero;
						Text = "";
					}

					public void Duplicate(UserData original)
					{
						Flags = original.Flags;
						NumberInt = original.NumberInt;
						Rectangle.xMin = original.Rectangle.xMin;
						Rectangle.yMin = original.Rectangle.yMin;
						Rectangle.xMax = original.Rectangle.xMax;
						Rectangle.yMax = original.Rectangle.yMax;
						Coordinate = original.Coordinate;
						Text = (true == string.IsNullOrEmpty(original.Text)) ? "" : string.Copy(original.Text);
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						UserData targetData = (UserData)target;
						return(	(Flags == targetData.Flags)
								&& (NumberInt == targetData.NumberInt)
								&& (Rectangle.xMin == targetData.Rectangle.xMin)
								&& (Rectangle.yMin == targetData.Rectangle.yMin)
								&& (Rectangle.xMax == targetData.Rectangle.xMax)
								&& (Rectangle.yMax == targetData.Rectangle.yMax)
								&& (Coordinate == targetData.Coordinate)
								&& (Text == targetData.Text)
							);
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions

					/* ----------------------------------------------- Enums & Constants */
					#region Enums & Constants
					[System.Flags]
					public enum FlagBit
					{
						VALID = 0x40000000,

						COORDINATE = 0x00000004,
						TEXT = 0x00000008,
						RECTANGLE = 0x00000002,
						NUMBER = 0x00000001,

						CLEAR = 0x00000000,
					}
					#endregion Enums & Constants
				}

				[System.Serializable]
				public struct Instance
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public FlagBit Flags;
					public int PlayCount;
					public float RateTime;
					public int OffsetStart;
					public int OffsetEnd;
					public string LabelStart;
					public string LabelEnd;

					public bool IsValid
					{
						get
						{
							return(0 != (Flags & FlagBit.VALID));
						}
					}
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public Instance(	FlagBit flags,
										int playCount,
										float rateTime,
										int offsetStart,
										int offsetEnd,
										string labelStart,
										string labelEnd
									)
					{
						Flags = flags;
						PlayCount = playCount;
						RateTime = rateTime;
						OffsetStart = offsetStart;
						OffsetEnd = offsetEnd;
						LabelStart = labelStart;
						LabelEnd = labelEnd;
					}

					public void CleanUp()
					{
						Flags = FlagBit.CLEAR;
						PlayCount = 1;
						RateTime = 1.0f;
						OffsetStart = 0;
						OffsetEnd = 0;
						LabelStart = "";
						LabelEnd = "";
					}

					public void Duplicate(Instance original)
					{
						Flags = original.Flags;
						PlayCount = original.PlayCount;
						RateTime = original.RateTime;
						OffsetStart = original.OffsetStart;
						OffsetEnd = original.OffsetEnd;
						LabelStart = string.Copy(original.LabelStart);
						LabelEnd = string.Copy(original.LabelEnd);
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						Instance targetData = (Instance)target;
						return(	(Flags == targetData.Flags)
									&& (PlayCount == targetData.PlayCount)
									&& (RateTime == targetData.RateTime)
									&& (OffsetStart == targetData.OffsetStart)
									&& (OffsetEnd == targetData.OffsetEnd)
									&& (LabelStart == targetData.LabelStart)
									&& (LabelEnd == targetData.LabelEnd)
							);
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions

					/* ----------------------------------------------- Enums & Constants */
					#region Enums & Constants
					[System.Flags]
					public enum FlagBit
					{
						VALID = 0x40000000,

						INDEPENDENT = 0x00000002,
						PINGPONG = 0x00000001,

						CLEAR = 0x00000000,
					}
					#endregion Enums & Constants
				}

				[System.Serializable]
				public struct Effect
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public FlagBit Flags;
					public int FrameStart;
					public float RateTime;

					public bool IsValid
					{
						get
						{
							return(0 != (Flags & FlagBit.VALID));
						}
					}
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public Effect(FlagBit flags, int frameStart, float rateTime)
					{
						Flags = flags;
						FrameStart = frameStart;
						RateTime = rateTime;
					}

					public void CleanUp()
					{
						Flags = FlagBit.CLEAR;
						FrameStart = 0;
						RateTime = 1.0f;
					}

					public void Duplicate(Effect original)
					{
						Flags = original.Flags;
						FrameStart = original.FrameStart;
						RateTime = original.RateTime;
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						Effect targetData = (Effect)target;
						return(	(Flags == targetData.Flags)
								&& (FrameStart == targetData.FrameStart)
								&& (RateTime == targetData.RateTime)
							);
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions

					/* ----------------------------------------------- Enums & Constants */
					#region Enums & Constants
					[System.Flags]
					public enum FlagBit
					{
						VALID = 0x40000000,

						INDEPENDENT = 0x00000002,
						PINGPONG = 0x00000001,	/* (Reserved) */

						CLEAR = 0x00000000,
					}
					#endregion Enums & Constants
				}

				[System.Serializable]
				public struct CoordinateFix
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public Vector3[] TableCoordinate;
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public void CleanUp()
					{
						TableCoordinate = null;
					}

					public void Duplicate(CoordinateFix original)
					{
						int count = original.TableCoordinate.Length;
						TableCoordinate = new Vector3[count];
						for(int i=0; i<count; i++)
						{
							TableCoordinate[i] = original.TableCoordinate[i];
						}
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						CoordinateFix targetData = (CoordinateFix)target;
						int count = TableCoordinate.Length;
						if(count != targetData.TableCoordinate.Length)
						{
							return(false);
						}
						for(int i=0; i<count; i++)
						{
							if(TableCoordinate[i] != targetData.TableCoordinate[i])
							{
								return(false);
							}
						}
						return(true);
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions
				}

				[System.Serializable]
				public struct UVFix
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public Vector2[] TableUV;
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public void CleanUp()
					{
						TableUV = null;
					}

					public void Duplicate(UVFix original)
					{
						int count = original.TableUV.Length;
						TableUV = new Vector2[count];
						for(int i=0; i<count; i++)
						{
							TableUV[i] = original.TableUV[i];
						}
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						UVFix targetData = (UVFix)target;
						int count = TableUV.Length;
						if(count != targetData.TableUV.Length)
						{
							return(false);
						}
						for(int i=0; i<count; i++)
						{
							if(TableUV[i] != targetData.TableUV[i])
							{
								return(false);
							}
						}
						return(true);
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions
				}

				[System.Serializable]
				public struct ColorBlendFix
				{
					/* ----------------------------------------------- Variables & Properties */
					#region Variables & Properties
					public Vector2[] TableUV;
					public Color32[] TableColorOverlay;
					#endregion Variables & Properties

					/* ----------------------------------------------- Functions */
					#region Functions
					public void CleanUp()
					{
						TableUV = null;
						TableColorOverlay = null;
					}

					public void Duplicate(ColorBlendFix original)
					{
						int count = original.TableUV.Length;
						TableUV = new Vector2[count];
						for(int i=0; i<count; i++)
						{
							TableUV[i] = original.TableUV[i];
						}

						count = original.TableColorOverlay.Length;
						TableColorOverlay = new Color32[count];
						for(int i=0; i<count; i++)
						{
							TableColorOverlay[i] = original.TableColorOverlay[i];
						}
					}

					public override bool Equals(System.Object target)
					{
						if((null == target) || (GetType() != target.GetType()))
						{
							return(false);
						}

						ColorBlendFix targetData = (ColorBlendFix)target;
						int count = TableUV.Length;
						if(count != targetData.TableUV.Length)
						{
							return(false);
						}
						for(int i=0; i<count; i++)
						{
							if(TableUV[i] != targetData.TableUV[i])
							{
								return(false);
							}
						}

						count = TableColorOverlay.Length;
						if(count != targetData.TableColorOverlay.Length)
						{
							return(false);
						}
						for(int i=0; i<count; i++)
						{
							if(false == TableColorOverlay[i].Equals(targetData.TableColorOverlay[i]))
							{
								return(false);
							}
						}
						return(true);
					}

					public override int GetHashCode()
					{
						return(base.GetHashCode());
					}
					#endregion Functions
				}
				#endregion Classes, Structs & Interfaces
			}
		}
	}
}
