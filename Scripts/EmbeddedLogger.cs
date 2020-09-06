using UnityEngine;

namespace Kogane
{
	public interface IEmbeddedLogger
	{
		void LogImpl();
		void LogWarningImpl();
		void LogErrorImpl();
	}

	public sealed class EmbeddedLogger : IEmbeddedLogger
	{
		private readonly string m_message;
		private readonly string m_format;

		private int m_number = 1;

		private string Format     => string.IsNullOrWhiteSpace( m_format ) ? DefaultFormat : m_format;
		private bool   HasMessage => !string.IsNullOrWhiteSpace( m_message );

		public static string DefaultFormat { private get; set; } = "{0}: {1}";

		private EmbeddedLogger() : this( string.Empty )
		{
		}

		private EmbeddedLogger( string message ) : this( message, string.Empty )
		{
		}

		private EmbeddedLogger( string message, string format )
		{
			m_message = message;
			m_format  = format;
		}

		void IEmbeddedLogger.LogImpl()
		{
			if ( HasMessage )
			{
				Debug.LogFormat( Format, m_message, m_number.ToString() );
			}
			else
			{
				Debug.Log( m_number.ToString() );
			}

			m_number++;
		}

		void IEmbeddedLogger.LogWarningImpl()
		{
			if ( HasMessage )
			{
				Debug.LogWarningFormat( Format, m_message, m_number.ToString() );
			}
			else
			{
				Debug.LogWarningFormat( m_number.ToString() );
			}

			m_number++;
		}

		void IEmbeddedLogger.LogErrorImpl()
		{
			if ( HasMessage )
			{
				Debug.LogErrorFormat( Format, m_message, m_number.ToString() );
			}
			else
			{
				Debug.LogErrorFormat( m_number.ToString() );
			}

			m_number++;
		}

		public static EmbeddedLogger Create()
		{
#if DISABLE_UNI_EMBEDDED_LOGGER
			return null;
#else
			return new EmbeddedLogger();
#endif
		}

		public static EmbeddedLogger Create( string message )
		{
#if DISABLE_UNI_EMBEDDED_LOGGER
			return null;
#else
			return new EmbeddedLogger( message );
#endif
		}

		public static EmbeddedLogger Create( string message, string format )
		{
#if DISABLE_UNI_EMBEDDED_LOGGER
			return null;
#else
			return new EmbeddedLogger( message, format );
#endif
		}
	}

	public static class IEmbeddedLoggerExt
	{
		private const string CONDITIONAL_STRING = "VdKFmRNySDAC";

#if DISABLE_UNI_EMBEDDED_LOGGER
		[System.Diagnostics.Conditional( CONDITIONAL_STRING )]
#endif
		public static void Log( this IEmbeddedLogger self )
		{
			self?.LogImpl();
		}

#if DISABLE_UNI_EMBEDDED_LOGGER
		[System.Diagnostics.Conditional( CONDITIONAL_STRING )]
#endif
		public static void LogWarning( this IEmbeddedLogger self )
		{
			self?.LogWarningImpl();
		}

#if DISABLE_UNI_EMBEDDED_LOGGER
		[System.Diagnostics.Conditional( CONDITIONAL_STRING )]
#endif
		public static void LogError( this IEmbeddedLogger self )
		{
			self?.LogErrorImpl();
		}
	}
}