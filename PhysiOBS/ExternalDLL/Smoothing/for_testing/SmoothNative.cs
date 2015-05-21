/*
* MATLAB Compiler: 6.0 (R2015a)
* Date: Wed May 20 10:45:44 2015
* Arguments: "-B" "macro_default" "-W" "dotnet:smoothing_testing,Smooth,0.0,private" "-T"
* "link:lib" "-d"
* "C:\Users\aliapis\Desktop\Smooth_via_Physiobs\smoothing_testing\for_testing" "-v"
* "class{Smooth:C:\Users\aliapis\Desktop\Smooth_via_Physiobs\smoothing_testing.m}" 
*/
using System;
using System.Reflection;
using System.IO;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace smoothing_testingNative
{

  /// <summary>
  /// The Smooth class provides a CLS compliant, Object (native) interface to the MATLAB
  /// functions contained in the files:
  /// <newpara></newpara>
  /// C:\Users\aliapis\Desktop\Smooth_via_Physiobs\smoothing_testing.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class Smooth : IDisposable
  {
    #region Constructors

    /// <summary internal= "true">
    /// The static constructor instantiates and initializes the MATLAB runtime instance.
    /// </summary>
    static Smooth()
    {
      if (MWMCR.MCRAppInitialized)
      {
        try
        {
          Assembly assembly= Assembly.GetExecutingAssembly();

          string ctfFilePath= assembly.Location;

          int lastDelimiter= ctfFilePath.LastIndexOf(@"\");

          ctfFilePath= ctfFilePath.Remove(lastDelimiter, (ctfFilePath.Length - lastDelimiter));

          string ctfFileName = "smoothing_testing.ctf";

          Stream embeddedCtfStream = null;

          String[] resourceStrings = assembly.GetManifestResourceNames();

          foreach (String name in resourceStrings)
          {
            if (name.Contains(ctfFileName))
            {
              embeddedCtfStream = assembly.GetManifestResourceStream(name);
              break;
            }
          }
          mcr= new MWMCR("",
                         ctfFilePath, embeddedCtfStream, true);
        }
        catch(Exception ex)
        {
          ex_ = new Exception("MWArray assembly failed to be initialized", ex);
        }
      }
      else
      {
        ex_ = new ApplicationException("MWArray assembly could not be initialized");
      }
    }


    /// <summary>
    /// Constructs a new instance of the Smooth class.
    /// </summary>
    public Smooth()
    {
      if(ex_ != null)
      {
        throw ex_;
      }
    }


    #endregion Constructors

    #region Finalize

    /// <summary internal= "true">
    /// Class destructor called by the CLR garbage collector.
    /// </summary>
    ~Smooth()
    {
      Dispose(false);
    }


    /// <summary>
    /// Frees the native resources associated with this object
    /// </summary>
    public void Dispose()
    {
      Dispose(true);

      GC.SuppressFinalize(this);
    }


    /// <summary internal= "true">
    /// Internal dispose function
    /// </summary>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        disposed= true;

        if (disposing)
        {
          // Free managed resources;
        }

        // Free native resources
      }
    }


    #endregion Finalize

    #region Methods

    /// <summary>
    /// Provides a single output, 0-input Objectinterface to the smoothing_testing MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object smoothing_testing()
    {
      return mcr.EvaluateFunction("smoothing_testing", new Object[]{});
    }


    /// <summary>
    /// Provides a single output, 1-input Objectinterface to the smoothing_testing MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <param name="original_signal">Input argument #1</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object smoothing_testing(Object original_signal)
    {
      return mcr.EvaluateFunction("smoothing_testing", original_signal);
    }


    /// <summary>
    /// Provides a single output, 2-input Objectinterface to the smoothing_testing MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <param name="original_signal">Input argument #1</param>
    /// <param name="ErrorGoal">Input argument #2</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object smoothing_testing(Object original_signal, Object ErrorGoal)
    {
      return mcr.EvaluateFunction("smoothing_testing", original_signal, ErrorGoal);
    }


    /// <summary>
    /// Provides a single output, 3-input Objectinterface to the smoothing_testing MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <param name="original_signal">Input argument #1</param>
    /// <param name="ErrorGoal">Input argument #2</param>
    /// <param name="sampling">Input argument #3</param>
    /// <returns>An Object containing the first output argument.</returns>
    ///
    public Object smoothing_testing(Object original_signal, Object ErrorGoal, Object 
                              sampling)
    {
      return mcr.EvaluateFunction("smoothing_testing", original_signal, ErrorGoal, sampling);
    }


    /// <summary>
    /// Provides the standard 0-input Object interface to the smoothing_testing MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] smoothing_testing(int numArgsOut)
    {
      return mcr.EvaluateFunction(numArgsOut, "smoothing_testing", new Object[]{});
    }


    /// <summary>
    /// Provides the standard 1-input Object interface to the smoothing_testing MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="original_signal">Input argument #1</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] smoothing_testing(int numArgsOut, Object original_signal)
    {
      return mcr.EvaluateFunction(numArgsOut, "smoothing_testing", original_signal);
    }


    /// <summary>
    /// Provides the standard 2-input Object interface to the smoothing_testing MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="original_signal">Input argument #1</param>
    /// <param name="ErrorGoal">Input argument #2</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] smoothing_testing(int numArgsOut, Object original_signal, Object 
                                ErrorGoal)
    {
      return mcr.EvaluateFunction(numArgsOut, "smoothing_testing", original_signal, ErrorGoal);
    }


    /// <summary>
    /// Provides the standard 3-input Object interface to the smoothing_testing MATLAB
    /// function.
    /// </summary>
    /// <remarks>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return.</param>
    /// <param name="original_signal">Input argument #1</param>
    /// <param name="ErrorGoal">Input argument #2</param>
    /// <param name="sampling">Input argument #3</param>
    /// <returns>An Array of length "numArgsOut" containing the output
    /// arguments.</returns>
    ///
    public Object[] smoothing_testing(int numArgsOut, Object original_signal, Object 
                                ErrorGoal, Object sampling)
    {
      return mcr.EvaluateFunction(numArgsOut, "smoothing_testing", original_signal, ErrorGoal, sampling);
    }


    /// <summary>
    /// Provides an interface for the smoothing_testing function in which the input and
    /// output
    /// arguments are specified as an array of Objects.
    /// </summary>
    /// <remarks>
    /// This method will allocate and return by reference the output argument
    /// array.<newpara></newpara>
    /// M-Documentation:
    /// Smoothing phase
    /// </remarks>
    /// <param name="numArgsOut">The number of output arguments to return</param>
    /// <param name= "argsOut">Array of Object output arguments</param>
    /// <param name= "argsIn">Array of Object input arguments</param>
    /// <param name= "varArgsIn">Array of Object representing variable input
    /// arguments</param>
    ///
    [MATLABSignature("smoothing_testing", 3, 1, 0)]
    protected void smoothing_testing(int numArgsOut, ref Object[] argsOut, Object[] argsIn, params Object[] varArgsIn)
    {
        mcr.EvaluateFunctionForTypeSafeCall("smoothing_testing", numArgsOut, ref argsOut, argsIn, varArgsIn);
    }

    /// <summary>
    /// This method will cause a MATLAB figure window to behave as a modal dialog box.
    /// The method will not return until all the figure windows associated with this
    /// component have been closed.
    /// </summary>
    /// <remarks>
    /// An application should only call this method when required to keep the
    /// MATLAB figure window from disappearing.  Other techniques, such as calling
    /// Console.ReadLine() from the application should be considered where
    /// possible.</remarks>
    ///
    public void WaitForFiguresToDie()
    {
      mcr.WaitForFiguresToDie();
    }



    #endregion Methods

    #region Class Members

    private static MWMCR mcr= null;

    private static Exception ex_= null;

    private bool disposed= false;

    #endregion Class Members
  }
}
