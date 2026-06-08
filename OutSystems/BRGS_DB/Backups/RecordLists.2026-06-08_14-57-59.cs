using System;
using System.Data;
using System.Collections;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;
using OutSystems.HubEdition.RuntimePlatform.NewRuntime;

namespace OutSystems.NssBRGS_DB {

	/// <summary>
	/// RecordList type <code>RLFretes_PagamentosRecordList</code> that represents a record list of
	///  <code>Fretes_Pagamentos</code>
	/// </summary>
	[Serializable()]
	public partial class RLFretes_PagamentosRecordList: GenericRecordList<RCFretes_PagamentosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFretes_PagamentosRecord GetElementDefaultValue() {
			return new RCFretes_PagamentosRecord("");
		}

		public T[] ToArray<T>(Func<RCFretes_PagamentosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFretes_PagamentosRecordList recordlist, Func<RCFretes_PagamentosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFretes_PagamentosRecordList(RCFretes_PagamentosRecord[] array) {
			RLFretes_PagamentosRecordList result = new RLFretes_PagamentosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFretes_PagamentosRecordList ToList<T>(T[] array, Func <T, RCFretes_PagamentosRecord> converter) {
			RLFretes_PagamentosRecordList result = new RLFretes_PagamentosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFretes_PagamentosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFretes_PagamentosRecord> converter) {
			RLFretes_PagamentosRecordList result = new RLFretes_PagamentosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFretes_PagamentosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFretes_PagamentosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFretes_PagamentosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFretes_PagamentosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFretes_PagamentosRecord> NewList() {
			return new RLFretes_PagamentosRecordList();
		}


	} // RLFretes_PagamentosRecordList

	/// <summary>
	/// RecordList type <code>RLCentrosCustos_DespesasRecordList</code> that represents a record list of
	///  <code>CentrosCustos_Despesas</code>
	/// </summary>
	[Serializable()]
	public partial class RLCentrosCustos_DespesasRecordList: GenericRecordList<RCCentrosCustos_DespesasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCCentrosCustos_DespesasRecord GetElementDefaultValue() {
			return new RCCentrosCustos_DespesasRecord("");
		}

		public T[] ToArray<T>(Func<RCCentrosCustos_DespesasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLCentrosCustos_DespesasRecordList recordlist, Func<RCCentrosCustos_DespesasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLCentrosCustos_DespesasRecordList(RCCentrosCustos_DespesasRecord[] array) {
			RLCentrosCustos_DespesasRecordList result = new RLCentrosCustos_DespesasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLCentrosCustos_DespesasRecordList ToList<T>(T[] array, Func <T, RCCentrosCustos_DespesasRecord> converter) {
			RLCentrosCustos_DespesasRecordList result = new RLCentrosCustos_DespesasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLCentrosCustos_DespesasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCCentrosCustos_DespesasRecord> converter) {
			RLCentrosCustos_DespesasRecordList result = new RLCentrosCustos_DespesasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLCentrosCustos_DespesasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLCentrosCustos_DespesasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLCentrosCustos_DespesasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLCentrosCustos_DespesasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCCentrosCustos_DespesasRecord> NewList() {
			return new RLCentrosCustos_DespesasRecordList();
		}


	} // RLCentrosCustos_DespesasRecordList

	/// <summary>
	/// RecordList type <code>RLCategoriasRecordList</code> that represents a record list of
	///  <code>Categorias</code>
	/// </summary>
	[Serializable()]
	public partial class RLCategoriasRecordList: GenericRecordList<RCCategoriasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCCategoriasRecord GetElementDefaultValue() {
			return new RCCategoriasRecord("");
		}

		public T[] ToArray<T>(Func<RCCategoriasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLCategoriasRecordList recordlist, Func<RCCategoriasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLCategoriasRecordList(RCCategoriasRecord[] array) {
			RLCategoriasRecordList result = new RLCategoriasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLCategoriasRecordList ToList<T>(T[] array, Func <T, RCCategoriasRecord> converter) {
			RLCategoriasRecordList result = new RLCategoriasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLCategoriasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCCategoriasRecord> converter) {
			RLCategoriasRecordList result = new RLCategoriasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLCategoriasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLCategoriasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLCategoriasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLCategoriasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCCategoriasRecord> NewList() {
			return new RLCategoriasRecordList();
		}


	} // RLCategoriasRecordList

	/// <summary>
	/// RecordList type <code>RLFasesRecordList</code> that represents a record list of <code>Fases</code>
	/// </summary>
	[Serializable()]
	public partial class RLFasesRecordList: GenericRecordList<RCFasesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFasesRecord GetElementDefaultValue() {
			return new RCFasesRecord("");
		}

		public T[] ToArray<T>(Func<RCFasesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFasesRecordList recordlist, Func<RCFasesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFasesRecordList(RCFasesRecord[] array) {
			RLFasesRecordList result = new RLFasesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFasesRecordList ToList<T>(T[] array, Func <T, RCFasesRecord> converter) {
			RLFasesRecordList result = new RLFasesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFasesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFasesRecord> converter) {
			RLFasesRecordList result = new RLFasesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFasesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFasesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFasesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFasesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFasesRecord> NewList() {
			return new RLFasesRecordList();
		}


	} // RLFasesRecordList

	/// <summary>
	/// RecordList type <code>RLMultasOcorrenciasRecordList</code> that represents a record list of
	///  <code>MultasOcorrencias</code>
	/// </summary>
	[Serializable()]
	public partial class RLMultasOcorrenciasRecordList: GenericRecordList<RCMultasOcorrenciasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCMultasOcorrenciasRecord GetElementDefaultValue() {
			return new RCMultasOcorrenciasRecord("");
		}

		public T[] ToArray<T>(Func<RCMultasOcorrenciasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLMultasOcorrenciasRecordList recordlist, Func<RCMultasOcorrenciasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLMultasOcorrenciasRecordList(RCMultasOcorrenciasRecord[] array) {
			RLMultasOcorrenciasRecordList result = new RLMultasOcorrenciasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLMultasOcorrenciasRecordList ToList<T>(T[] array, Func <T, RCMultasOcorrenciasRecord> converter) {
			RLMultasOcorrenciasRecordList result = new RLMultasOcorrenciasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLMultasOcorrenciasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCMultasOcorrenciasRecord> converter) {
			RLMultasOcorrenciasRecordList result = new RLMultasOcorrenciasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLMultasOcorrenciasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLMultasOcorrenciasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLMultasOcorrenciasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLMultasOcorrenciasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(7, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCMultasOcorrenciasRecord> NewList() {
			return new RLMultasOcorrenciasRecordList();
		}


	} // RLMultasOcorrenciasRecordList

	/// <summary>
	/// RecordList type <code>RLAtividadesRecordList</code> that represents a record list of
	///  <code>Atividades</code>
	/// </summary>
	[Serializable()]
	public partial class RLAtividadesRecordList: GenericRecordList<RCAtividadesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCAtividadesRecord GetElementDefaultValue() {
			return new RCAtividadesRecord("");
		}

		public T[] ToArray<T>(Func<RCAtividadesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLAtividadesRecordList recordlist, Func<RCAtividadesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLAtividadesRecordList(RCAtividadesRecord[] array) {
			RLAtividadesRecordList result = new RLAtividadesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLAtividadesRecordList ToList<T>(T[] array, Func <T, RCAtividadesRecord> converter) {
			RLAtividadesRecordList result = new RLAtividadesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLAtividadesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCAtividadesRecord> converter) {
			RLAtividadesRecordList result = new RLAtividadesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLAtividadesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLAtividadesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLAtividadesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLAtividadesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCAtividadesRecord> NewList() {
			return new RLAtividadesRecordList();
		}


	} // RLAtividadesRecordList

	/// <summary>
	/// RecordList type <code>RLDespesasRecordList</code> that represents a record list of
	///  <code>Despesas</code>
	/// </summary>
	[Serializable()]
	public partial class RLDespesasRecordList: GenericRecordList<RCDespesasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCDespesasRecord GetElementDefaultValue() {
			return new RCDespesasRecord("");
		}

		public T[] ToArray<T>(Func<RCDespesasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLDespesasRecordList recordlist, Func<RCDespesasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLDespesasRecordList(RCDespesasRecord[] array) {
			RLDespesasRecordList result = new RLDespesasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLDespesasRecordList ToList<T>(T[] array, Func <T, RCDespesasRecord> converter) {
			RLDespesasRecordList result = new RLDespesasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLDespesasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCDespesasRecord> converter) {
			RLDespesasRecordList result = new RLDespesasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLDespesasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLDespesasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLDespesasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLDespesasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(4, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCDespesasRecord> NewList() {
			return new RLDespesasRecordList();
		}


	} // RLDespesasRecordList

	/// <summary>
	/// RecordList type <code>RLAbastecimentosRecordList</code> that represents a record list of
	///  <code>Abastecimentos</code>
	/// </summary>
	[Serializable()]
	public partial class RLAbastecimentosRecordList: GenericRecordList<RCAbastecimentosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCAbastecimentosRecord GetElementDefaultValue() {
			return new RCAbastecimentosRecord("");
		}

		public T[] ToArray<T>(Func<RCAbastecimentosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLAbastecimentosRecordList recordlist, Func<RCAbastecimentosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLAbastecimentosRecordList(RCAbastecimentosRecord[] array) {
			RLAbastecimentosRecordList result = new RLAbastecimentosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLAbastecimentosRecordList ToList<T>(T[] array, Func <T, RCAbastecimentosRecord> converter) {
			RLAbastecimentosRecordList result = new RLAbastecimentosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLAbastecimentosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCAbastecimentosRecord> converter) {
			RLAbastecimentosRecordList result = new RLAbastecimentosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLAbastecimentosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLAbastecimentosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLAbastecimentosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLAbastecimentosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(19, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCAbastecimentosRecord> NewList() {
			return new RLAbastecimentosRecordList();
		}


	} // RLAbastecimentosRecordList

	/// <summary>
	/// RecordList type <code>RLVeiculosRecordList</code> that represents a record list of
	///  <code>Veiculos</code>
	/// </summary>
	[Serializable()]
	public partial class RLVeiculosRecordList: GenericRecordList<RCVeiculosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCVeiculosRecord GetElementDefaultValue() {
			return new RCVeiculosRecord("");
		}

		public T[] ToArray<T>(Func<RCVeiculosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLVeiculosRecordList recordlist, Func<RCVeiculosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLVeiculosRecordList(RCVeiculosRecord[] array) {
			RLVeiculosRecordList result = new RLVeiculosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLVeiculosRecordList ToList<T>(T[] array, Func <T, RCVeiculosRecord> converter) {
			RLVeiculosRecordList result = new RLVeiculosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLVeiculosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCVeiculosRecord> converter) {
			RLVeiculosRecordList result = new RLVeiculosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLVeiculosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVeiculosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVeiculosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLVeiculosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(15, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCVeiculosRecord> NewList() {
			return new RLVeiculosRecordList();
		}


	} // RLVeiculosRecordList

	/// <summary>
	/// RecordList type <code>RLFornecedoresRecordList</code> that represents a record list of
	///  <code>Fornecedores</code>
	/// </summary>
	[Serializable()]
	public partial class RLFornecedoresRecordList: GenericRecordList<RCFornecedoresRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFornecedoresRecord GetElementDefaultValue() {
			return new RCFornecedoresRecord("");
		}

		public T[] ToArray<T>(Func<RCFornecedoresRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFornecedoresRecordList recordlist, Func<RCFornecedoresRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFornecedoresRecordList(RCFornecedoresRecord[] array) {
			RLFornecedoresRecordList result = new RLFornecedoresRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFornecedoresRecordList ToList<T>(T[] array, Func <T, RCFornecedoresRecord> converter) {
			RLFornecedoresRecordList result = new RLFornecedoresRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFornecedoresRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFornecedoresRecord> converter) {
			RLFornecedoresRecordList result = new RLFornecedoresRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFornecedoresRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFornecedoresRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFornecedoresRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFornecedoresRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(23, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFornecedoresRecord> NewList() {
			return new RLFornecedoresRecordList();
		}


	} // RLFornecedoresRecordList

	/// <summary>
	/// RecordList type <code>RLUsuariosDespesasRecordList</code> that represents a record list of
	///  <code>UsuariosDespesas</code>
	/// </summary>
	[Serializable()]
	public partial class RLUsuariosDespesasRecordList: GenericRecordList<RCUsuariosDespesasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCUsuariosDespesasRecord GetElementDefaultValue() {
			return new RCUsuariosDespesasRecord("");
		}

		public T[] ToArray<T>(Func<RCUsuariosDespesasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLUsuariosDespesasRecordList recordlist, Func<RCUsuariosDespesasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLUsuariosDespesasRecordList(RCUsuariosDespesasRecord[] array) {
			RLUsuariosDespesasRecordList result = new RLUsuariosDespesasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLUsuariosDespesasRecordList ToList<T>(T[] array, Func <T, RCUsuariosDespesasRecord> converter) {
			RLUsuariosDespesasRecordList result = new RLUsuariosDespesasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLUsuariosDespesasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCUsuariosDespesasRecord> converter) {
			RLUsuariosDespesasRecordList result = new RLUsuariosDespesasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLUsuariosDespesasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosDespesasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosDespesasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLUsuariosDespesasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCUsuariosDespesasRecord> NewList() {
			return new RLUsuariosDespesasRecordList();
		}


	} // RLUsuariosDespesasRecordList

	/// <summary>
	/// RecordList type <code>RLNotasFiscaisItensRecordList</code> that represents a record list of
	///  <code>NotasFiscaisItens</code>
	/// </summary>
	[Serializable()]
	public partial class RLNotasFiscaisItensRecordList: GenericRecordList<RCNotasFiscaisItensRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCNotasFiscaisItensRecord GetElementDefaultValue() {
			return new RCNotasFiscaisItensRecord("");
		}

		public T[] ToArray<T>(Func<RCNotasFiscaisItensRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLNotasFiscaisItensRecordList recordlist, Func<RCNotasFiscaisItensRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLNotasFiscaisItensRecordList(RCNotasFiscaisItensRecord[] array) {
			RLNotasFiscaisItensRecordList result = new RLNotasFiscaisItensRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLNotasFiscaisItensRecordList ToList<T>(T[] array, Func <T, RCNotasFiscaisItensRecord> converter) {
			RLNotasFiscaisItensRecordList result = new RLNotasFiscaisItensRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLNotasFiscaisItensRecordList FromRestList<T>(RestList<T> restList, Func <T, RCNotasFiscaisItensRecord> converter) {
			RLNotasFiscaisItensRecordList result = new RLNotasFiscaisItensRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLNotasFiscaisItensRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLNotasFiscaisItensRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLNotasFiscaisItensRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLNotasFiscaisItensRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(6, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCNotasFiscaisItensRecord> NewList() {
			return new RLNotasFiscaisItensRecordList();
		}


	} // RLNotasFiscaisItensRecordList

	/// <summary>
	/// RecordList type <code>RLMotoristasRecordList</code> that represents a record list of
	///  <code>Motoristas</code>
	/// </summary>
	[Serializable()]
	public partial class RLMotoristasRecordList: GenericRecordList<RCMotoristasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCMotoristasRecord GetElementDefaultValue() {
			return new RCMotoristasRecord("");
		}

		public T[] ToArray<T>(Func<RCMotoristasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLMotoristasRecordList recordlist, Func<RCMotoristasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLMotoristasRecordList(RCMotoristasRecord[] array) {
			RLMotoristasRecordList result = new RLMotoristasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLMotoristasRecordList ToList<T>(T[] array, Func <T, RCMotoristasRecord> converter) {
			RLMotoristasRecordList result = new RLMotoristasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLMotoristasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCMotoristasRecord> converter) {
			RLMotoristasRecordList result = new RLMotoristasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLMotoristasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLMotoristasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLMotoristasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLMotoristasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(7, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCMotoristasRecord> NewList() {
			return new RLMotoristasRecordList();
		}


	} // RLMotoristasRecordList

	/// <summary>
	/// RecordList type <code>RLEmpresasRecordList</code> that represents a record list of
	///  <code>Empresas</code>
	/// </summary>
	[Serializable()]
	public partial class RLEmpresasRecordList: GenericRecordList<RCEmpresasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCEmpresasRecord GetElementDefaultValue() {
			return new RCEmpresasRecord("");
		}

		public T[] ToArray<T>(Func<RCEmpresasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLEmpresasRecordList recordlist, Func<RCEmpresasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLEmpresasRecordList(RCEmpresasRecord[] array) {
			RLEmpresasRecordList result = new RLEmpresasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLEmpresasRecordList ToList<T>(T[] array, Func <T, RCEmpresasRecord> converter) {
			RLEmpresasRecordList result = new RLEmpresasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLEmpresasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCEmpresasRecord> converter) {
			RLEmpresasRecordList result = new RLEmpresasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLEmpresasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpresasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpresasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLEmpresasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(12, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCEmpresasRecord> NewList() {
			return new RLEmpresasRecordList();
		}


	} // RLEmpresasRecordList

	/// <summary>
	/// RecordList type <code>RLGeradores_ManutencoesRecordList</code> that represents a record list of
	///  <code>Geradores_Manutencoes</code>
	/// </summary>
	[Serializable()]
	public partial class RLGeradores_ManutencoesRecordList: GenericRecordList<RCGeradores_ManutencoesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCGeradores_ManutencoesRecord GetElementDefaultValue() {
			return new RCGeradores_ManutencoesRecord("");
		}

		public T[] ToArray<T>(Func<RCGeradores_ManutencoesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLGeradores_ManutencoesRecordList recordlist, Func<RCGeradores_ManutencoesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLGeradores_ManutencoesRecordList(RCGeradores_ManutencoesRecord[] array) {
			RLGeradores_ManutencoesRecordList result = new RLGeradores_ManutencoesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLGeradores_ManutencoesRecordList ToList<T>(T[] array, Func <T, RCGeradores_ManutencoesRecord> converter) {
			RLGeradores_ManutencoesRecordList result = new RLGeradores_ManutencoesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLGeradores_ManutencoesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCGeradores_ManutencoesRecord> converter) {
			RLGeradores_ManutencoesRecordList result = new RLGeradores_ManutencoesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLGeradores_ManutencoesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLGeradores_ManutencoesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLGeradores_ManutencoesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLGeradores_ManutencoesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(5, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCGeradores_ManutencoesRecord> NewList() {
			return new RLGeradores_ManutencoesRecordList();
		}


	} // RLGeradores_ManutencoesRecordList

	/// <summary>
	/// RecordList type <code>RLClientesRecordList</code> that represents a record list of
	///  <code>Clientes</code>
	/// </summary>
	[Serializable()]
	public partial class RLClientesRecordList: GenericRecordList<RCClientesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCClientesRecord GetElementDefaultValue() {
			return new RCClientesRecord("");
		}

		public T[] ToArray<T>(Func<RCClientesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLClientesRecordList recordlist, Func<RCClientesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLClientesRecordList(RCClientesRecord[] array) {
			RLClientesRecordList result = new RLClientesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLClientesRecordList ToList<T>(T[] array, Func <T, RCClientesRecord> converter) {
			RLClientesRecordList result = new RLClientesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLClientesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCClientesRecord> converter) {
			RLClientesRecordList result = new RLClientesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLClientesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLClientesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLClientesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLClientesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(23, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCClientesRecord> NewList() {
			return new RLClientesRecordList();
		}


	} // RLClientesRecordList

	/// <summary>
	/// RecordList type <code>RLObrasEtapas_FasesRecordList</code> that represents a record list of
	///  <code>ObrasEtapas_Fases</code>
	/// </summary>
	[Serializable()]
	public partial class RLObrasEtapas_FasesRecordList: GenericRecordList<RCObrasEtapas_FasesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCObrasEtapas_FasesRecord GetElementDefaultValue() {
			return new RCObrasEtapas_FasesRecord("");
		}

		public T[] ToArray<T>(Func<RCObrasEtapas_FasesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLObrasEtapas_FasesRecordList recordlist, Func<RCObrasEtapas_FasesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLObrasEtapas_FasesRecordList(RCObrasEtapas_FasesRecord[] array) {
			RLObrasEtapas_FasesRecordList result = new RLObrasEtapas_FasesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLObrasEtapas_FasesRecordList ToList<T>(T[] array, Func <T, RCObrasEtapas_FasesRecord> converter) {
			RLObrasEtapas_FasesRecordList result = new RLObrasEtapas_FasesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLObrasEtapas_FasesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCObrasEtapas_FasesRecord> converter) {
			RLObrasEtapas_FasesRecordList result = new RLObrasEtapas_FasesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLObrasEtapas_FasesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapas_FasesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapas_FasesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLObrasEtapas_FasesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(6, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCObrasEtapas_FasesRecord> NewList() {
			return new RLObrasEtapas_FasesRecordList();
		}


	} // RLObrasEtapas_FasesRecordList

	/// <summary>
	/// RecordList type <code>RLGeradores_UsosRecordList</code> that represents a record list of
	///  <code>Geradores_Usos</code>
	/// </summary>
	[Serializable()]
	public partial class RLGeradores_UsosRecordList: GenericRecordList<RCGeradores_UsosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCGeradores_UsosRecord GetElementDefaultValue() {
			return new RCGeradores_UsosRecord("");
		}

		public T[] ToArray<T>(Func<RCGeradores_UsosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLGeradores_UsosRecordList recordlist, Func<RCGeradores_UsosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLGeradores_UsosRecordList(RCGeradores_UsosRecord[] array) {
			RLGeradores_UsosRecordList result = new RLGeradores_UsosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLGeradores_UsosRecordList ToList<T>(T[] array, Func <T, RCGeradores_UsosRecord> converter) {
			RLGeradores_UsosRecordList result = new RLGeradores_UsosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLGeradores_UsosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCGeradores_UsosRecord> converter) {
			RLGeradores_UsosRecordList result = new RLGeradores_UsosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLGeradores_UsosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLGeradores_UsosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLGeradores_UsosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLGeradores_UsosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(6, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCGeradores_UsosRecord> NewList() {
			return new RLGeradores_UsosRecordList();
		}


	} // RLGeradores_UsosRecordList

	/// <summary>
	/// RecordList type <code>RLUsuariosUENRecordList</code> that represents a record list of
	///  <code>UsuariosUEN</code>
	/// </summary>
	[Serializable()]
	public partial class RLUsuariosUENRecordList: GenericRecordList<RCUsuariosUENRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCUsuariosUENRecord GetElementDefaultValue() {
			return new RCUsuariosUENRecord("");
		}

		public T[] ToArray<T>(Func<RCUsuariosUENRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLUsuariosUENRecordList recordlist, Func<RCUsuariosUENRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLUsuariosUENRecordList(RCUsuariosUENRecord[] array) {
			RLUsuariosUENRecordList result = new RLUsuariosUENRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLUsuariosUENRecordList ToList<T>(T[] array, Func <T, RCUsuariosUENRecord> converter) {
			RLUsuariosUENRecordList result = new RLUsuariosUENRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLUsuariosUENRecordList FromRestList<T>(RestList<T> restList, Func <T, RCUsuariosUENRecord> converter) {
			RLUsuariosUENRecordList result = new RLUsuariosUENRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLUsuariosUENRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosUENRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosUENRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLUsuariosUENRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCUsuariosUENRecord> NewList() {
			return new RLUsuariosUENRecordList();
		}


	} // RLUsuariosUENRecordList

	/// <summary>
	/// RecordList type <code>RLUENRecordList</code> that represents a record list of <code>UEN</code>
	/// </summary>
	[Serializable()]
	public partial class RLUENRecordList: GenericRecordList<RCUENRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCUENRecord GetElementDefaultValue() {
			return new RCUENRecord("");
		}

		public T[] ToArray<T>(Func<RCUENRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLUENRecordList recordlist, Func<RCUENRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLUENRecordList(RCUENRecord[] array) {
			RLUENRecordList result = new RLUENRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLUENRecordList ToList<T>(T[] array, Func <T, RCUENRecord> converter) {
			RLUENRecordList result = new RLUENRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLUENRecordList FromRestList<T>(RestList<T> restList, Func <T, RCUENRecord> converter) {
			RLUENRecordList result = new RLUENRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLUENRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUENRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUENRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLUENRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(4, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCUENRecord> NewList() {
			return new RLUENRecordList();
		}


	} // RLUENRecordList

	/// <summary>
	/// RecordList type <code>RLMultasRecordList</code> that represents a record list of
	///  <code>Multas</code>
	/// </summary>
	[Serializable()]
	public partial class RLMultasRecordList: GenericRecordList<RCMultasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCMultasRecord GetElementDefaultValue() {
			return new RCMultasRecord("");
		}

		public T[] ToArray<T>(Func<RCMultasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLMultasRecordList recordlist, Func<RCMultasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLMultasRecordList(RCMultasRecord[] array) {
			RLMultasRecordList result = new RLMultasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLMultasRecordList ToList<T>(T[] array, Func <T, RCMultasRecord> converter) {
			RLMultasRecordList result = new RLMultasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLMultasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCMultasRecord> converter) {
			RLMultasRecordList result = new RLMultasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLMultasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLMultasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLMultasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLMultasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(9, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCMultasRecord> NewList() {
			return new RLMultasRecordList();
		}


	} // RLMultasRecordList

	/// <summary>
	/// RecordList type <code>RLObrasEtapas_GastosRealizadosRecordList</code> that represents a record list
	///  of <code>ObrasEtapas_GastosRealizados</code>
	/// </summary>
	[Serializable()]
	public partial class RLObrasEtapas_GastosRealizadosRecordList: GenericRecordList<RCObrasEtapas_GastosRealizadosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCObrasEtapas_GastosRealizadosRecord GetElementDefaultValue() {
			return new RCObrasEtapas_GastosRealizadosRecord("");
		}

		public T[] ToArray<T>(Func<RCObrasEtapas_GastosRealizadosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLObrasEtapas_GastosRealizadosRecordList recordlist, Func<RCObrasEtapas_GastosRealizadosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLObrasEtapas_GastosRealizadosRecordList(RCObrasEtapas_GastosRealizadosRecord[] array) {
			RLObrasEtapas_GastosRealizadosRecordList result = new RLObrasEtapas_GastosRealizadosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLObrasEtapas_GastosRealizadosRecordList ToList<T>(T[] array, Func <T, RCObrasEtapas_GastosRealizadosRecord> converter) {
			RLObrasEtapas_GastosRealizadosRecordList result = new RLObrasEtapas_GastosRealizadosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLObrasEtapas_GastosRealizadosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCObrasEtapas_GastosRealizadosRecord> converter) {
			RLObrasEtapas_GastosRealizadosRecordList result = new RLObrasEtapas_GastosRealizadosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLObrasEtapas_GastosRealizadosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapas_GastosRealizadosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapas_GastosRealizadosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLObrasEtapas_GastosRealizadosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(10, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCObrasEtapas_GastosRealizadosRecord> NewList() {
			return new RLObrasEtapas_GastosRealizadosRecordList();
		}


	} // RLObrasEtapas_GastosRealizadosRecordList

	/// <summary>
	/// RecordList type <code>RLFretesRecordList</code> that represents a record list of
	///  <code>Fretes</code>
	/// </summary>
	[Serializable()]
	public partial class RLFretesRecordList: GenericRecordList<RCFretesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFretesRecord GetElementDefaultValue() {
			return new RCFretesRecord("");
		}

		public T[] ToArray<T>(Func<RCFretesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFretesRecordList recordlist, Func<RCFretesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFretesRecordList(RCFretesRecord[] array) {
			RLFretesRecordList result = new RLFretesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFretesRecordList ToList<T>(T[] array, Func <T, RCFretesRecord> converter) {
			RLFretesRecordList result = new RLFretesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFretesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFretesRecord> converter) {
			RLFretesRecordList result = new RLFretesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFretesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFretesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFretesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFretesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(8, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFretesRecord> NewList() {
			return new RLFretesRecordList();
		}


	} // RLFretesRecordList

	/// <summary>
	/// RecordList type <code>RLEmpresas_ContasBancariasRecordList</code> that represents a record list of
	///  <code>Empresas_ContasBancarias</code>
	/// </summary>
	[Serializable()]
	public partial class RLEmpresas_ContasBancariasRecordList: GenericRecordList<RCEmpresas_ContasBancariasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCEmpresas_ContasBancariasRecord GetElementDefaultValue() {
			return new RCEmpresas_ContasBancariasRecord("");
		}

		public T[] ToArray<T>(Func<RCEmpresas_ContasBancariasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLEmpresas_ContasBancariasRecordList recordlist, Func<RCEmpresas_ContasBancariasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLEmpresas_ContasBancariasRecordList(RCEmpresas_ContasBancariasRecord[] array) {
			RLEmpresas_ContasBancariasRecordList result = new RLEmpresas_ContasBancariasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLEmpresas_ContasBancariasRecordList ToList<T>(T[] array, Func <T, RCEmpresas_ContasBancariasRecord> converter) {
			RLEmpresas_ContasBancariasRecordList result = new RLEmpresas_ContasBancariasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLEmpresas_ContasBancariasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCEmpresas_ContasBancariasRecord> converter) {
			RLEmpresas_ContasBancariasRecordList result = new RLEmpresas_ContasBancariasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLEmpresas_ContasBancariasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpresas_ContasBancariasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpresas_ContasBancariasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLEmpresas_ContasBancariasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(7, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCEmpresas_ContasBancariasRecord> NewList() {
			return new RLEmpresas_ContasBancariasRecordList();
		}


	} // RLEmpresas_ContasBancariasRecordList

	/// <summary>
	/// RecordList type <code>RLGeradoresRecordList</code> that represents a record list of
	///  <code>Geradores</code>
	/// </summary>
	[Serializable()]
	public partial class RLGeradoresRecordList: GenericRecordList<RCGeradoresRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCGeradoresRecord GetElementDefaultValue() {
			return new RCGeradoresRecord("");
		}

		public T[] ToArray<T>(Func<RCGeradoresRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLGeradoresRecordList recordlist, Func<RCGeradoresRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLGeradoresRecordList(RCGeradoresRecord[] array) {
			RLGeradoresRecordList result = new RLGeradoresRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLGeradoresRecordList ToList<T>(T[] array, Func <T, RCGeradoresRecord> converter) {
			RLGeradoresRecordList result = new RLGeradoresRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLGeradoresRecordList FromRestList<T>(RestList<T> restList, Func <T, RCGeradoresRecord> converter) {
			RLGeradoresRecordList result = new RLGeradoresRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLGeradoresRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLGeradoresRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLGeradoresRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLGeradoresRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(13, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCGeradoresRecord> NewList() {
			return new RLGeradoresRecordList();
		}


	} // RLGeradoresRecordList

	/// <summary>
	/// RecordList type <code>RLUsuariosPermissoesRecordList</code> that represents a record list of
	///  <code>UsuariosPermissoes</code>
	/// </summary>
	[Serializable()]
	public partial class RLUsuariosPermissoesRecordList: GenericRecordList<RCUsuariosPermissoesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCUsuariosPermissoesRecord GetElementDefaultValue() {
			return new RCUsuariosPermissoesRecord("");
		}

		public T[] ToArray<T>(Func<RCUsuariosPermissoesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLUsuariosPermissoesRecordList recordlist, Func<RCUsuariosPermissoesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLUsuariosPermissoesRecordList(RCUsuariosPermissoesRecord[] array) {
			RLUsuariosPermissoesRecordList result = new RLUsuariosPermissoesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLUsuariosPermissoesRecordList ToList<T>(T[] array, Func <T, RCUsuariosPermissoesRecord> converter) {
			RLUsuariosPermissoesRecordList result = new RLUsuariosPermissoesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLUsuariosPermissoesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCUsuariosPermissoesRecord> converter) {
			RLUsuariosPermissoesRecordList result = new RLUsuariosPermissoesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLUsuariosPermissoesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosPermissoesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosPermissoesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLUsuariosPermissoesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(4, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCUsuariosPermissoesRecord> NewList() {
			return new RLUsuariosPermissoesRecordList();
		}


	} // RLUsuariosPermissoesRecordList

	/// <summary>
	/// RecordList type <code>RLEmpilhadeirasRecordList</code> that represents a record list of
	///  <code>Empilhadeiras</code>
	/// </summary>
	[Serializable()]
	public partial class RLEmpilhadeirasRecordList: GenericRecordList<RCEmpilhadeirasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCEmpilhadeirasRecord GetElementDefaultValue() {
			return new RCEmpilhadeirasRecord("");
		}

		public T[] ToArray<T>(Func<RCEmpilhadeirasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLEmpilhadeirasRecordList recordlist, Func<RCEmpilhadeirasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLEmpilhadeirasRecordList(RCEmpilhadeirasRecord[] array) {
			RLEmpilhadeirasRecordList result = new RLEmpilhadeirasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLEmpilhadeirasRecordList ToList<T>(T[] array, Func <T, RCEmpilhadeirasRecord> converter) {
			RLEmpilhadeirasRecordList result = new RLEmpilhadeirasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLEmpilhadeirasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCEmpilhadeirasRecord> converter) {
			RLEmpilhadeirasRecordList result = new RLEmpilhadeirasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLEmpilhadeirasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpilhadeirasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpilhadeirasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLEmpilhadeirasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(15, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCEmpilhadeirasRecord> NewList() {
			return new RLEmpilhadeirasRecordList();
		}


	} // RLEmpilhadeirasRecordList

	/// <summary>
	/// RecordList type <code>RLFornecedores_ContasBancariasRecordList</code> that represents a record list
	///  of <code>Fornecedores_ContasBancarias</code>
	/// </summary>
	[Serializable()]
	public partial class RLFornecedores_ContasBancariasRecordList: GenericRecordList<RCFornecedores_ContasBancariasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFornecedores_ContasBancariasRecord GetElementDefaultValue() {
			return new RCFornecedores_ContasBancariasRecord("");
		}

		public T[] ToArray<T>(Func<RCFornecedores_ContasBancariasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFornecedores_ContasBancariasRecordList recordlist, Func<RCFornecedores_ContasBancariasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFornecedores_ContasBancariasRecordList(RCFornecedores_ContasBancariasRecord[] array) {
			RLFornecedores_ContasBancariasRecordList result = new RLFornecedores_ContasBancariasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFornecedores_ContasBancariasRecordList ToList<T>(T[] array, Func <T, RCFornecedores_ContasBancariasRecord> converter) {
			RLFornecedores_ContasBancariasRecordList result = new RLFornecedores_ContasBancariasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFornecedores_ContasBancariasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFornecedores_ContasBancariasRecord> converter) {
			RLFornecedores_ContasBancariasRecordList result = new RLFornecedores_ContasBancariasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFornecedores_ContasBancariasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFornecedores_ContasBancariasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFornecedores_ContasBancariasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFornecedores_ContasBancariasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(7, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFornecedores_ContasBancariasRecord> NewList() {
			return new RLFornecedores_ContasBancariasRecordList();
		}


	} // RLFornecedores_ContasBancariasRecordList

	/// <summary>
	/// RecordList type <code>RLNotasFiscaisRecordList</code> that represents a record list of
	///  <code>NotasFiscais</code>
	/// </summary>
	[Serializable()]
	public partial class RLNotasFiscaisRecordList: GenericRecordList<RCNotasFiscaisRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCNotasFiscaisRecord GetElementDefaultValue() {
			return new RCNotasFiscaisRecord("");
		}

		public T[] ToArray<T>(Func<RCNotasFiscaisRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLNotasFiscaisRecordList recordlist, Func<RCNotasFiscaisRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLNotasFiscaisRecordList(RCNotasFiscaisRecord[] array) {
			RLNotasFiscaisRecordList result = new RLNotasFiscaisRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLNotasFiscaisRecordList ToList<T>(T[] array, Func <T, RCNotasFiscaisRecord> converter) {
			RLNotasFiscaisRecordList result = new RLNotasFiscaisRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLNotasFiscaisRecordList FromRestList<T>(RestList<T> restList, Func <T, RCNotasFiscaisRecord> converter) {
			RLNotasFiscaisRecordList result = new RLNotasFiscaisRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLNotasFiscaisRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLNotasFiscaisRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLNotasFiscaisRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLNotasFiscaisRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(41, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCNotasFiscaisRecord> NewList() {
			return new RLNotasFiscaisRecordList();
		}


	} // RLNotasFiscaisRecordList

	/// <summary>
	/// RecordList type <code>RLEmpilhadeiras_ManutencoesRecordList</code> that represents a record list of
	///  <code>Empilhadeiras_Manutencoes</code>
	/// </summary>
	[Serializable()]
	public partial class RLEmpilhadeiras_ManutencoesRecordList: GenericRecordList<RCEmpilhadeiras_ManutencoesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCEmpilhadeiras_ManutencoesRecord GetElementDefaultValue() {
			return new RCEmpilhadeiras_ManutencoesRecord("");
		}

		public T[] ToArray<T>(Func<RCEmpilhadeiras_ManutencoesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLEmpilhadeiras_ManutencoesRecordList recordlist, Func<RCEmpilhadeiras_ManutencoesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLEmpilhadeiras_ManutencoesRecordList(RCEmpilhadeiras_ManutencoesRecord[] array) {
			RLEmpilhadeiras_ManutencoesRecordList result = new RLEmpilhadeiras_ManutencoesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLEmpilhadeiras_ManutencoesRecordList ToList<T>(T[] array, Func <T, RCEmpilhadeiras_ManutencoesRecord> converter) {
			RLEmpilhadeiras_ManutencoesRecordList result = new RLEmpilhadeiras_ManutencoesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLEmpilhadeiras_ManutencoesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCEmpilhadeiras_ManutencoesRecord> converter) {
			RLEmpilhadeiras_ManutencoesRecordList result = new RLEmpilhadeiras_ManutencoesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLEmpilhadeiras_ManutencoesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpilhadeiras_ManutencoesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpilhadeiras_ManutencoesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLEmpilhadeiras_ManutencoesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(5, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCEmpilhadeiras_ManutencoesRecord> NewList() {
			return new RLEmpilhadeiras_ManutencoesRecordList();
		}


	} // RLEmpilhadeiras_ManutencoesRecordList

	/// <summary>
	/// RecordList type <code>RLUEN_CentrosCustosRecordList</code> that represents a record list of
	///  <code>UEN_CentrosCustos</code>
	/// </summary>
	[Serializable()]
	public partial class RLUEN_CentrosCustosRecordList: GenericRecordList<RCUEN_CentrosCustosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCUEN_CentrosCustosRecord GetElementDefaultValue() {
			return new RCUEN_CentrosCustosRecord("");
		}

		public T[] ToArray<T>(Func<RCUEN_CentrosCustosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLUEN_CentrosCustosRecordList recordlist, Func<RCUEN_CentrosCustosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLUEN_CentrosCustosRecordList(RCUEN_CentrosCustosRecord[] array) {
			RLUEN_CentrosCustosRecordList result = new RLUEN_CentrosCustosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLUEN_CentrosCustosRecordList ToList<T>(T[] array, Func <T, RCUEN_CentrosCustosRecord> converter) {
			RLUEN_CentrosCustosRecordList result = new RLUEN_CentrosCustosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLUEN_CentrosCustosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCUEN_CentrosCustosRecord> converter) {
			RLUEN_CentrosCustosRecordList result = new RLUEN_CentrosCustosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLUEN_CentrosCustosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUEN_CentrosCustosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUEN_CentrosCustosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLUEN_CentrosCustosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCUEN_CentrosCustosRecord> NewList() {
			return new RLUEN_CentrosCustosRecordList();
		}


	} // RLUEN_CentrosCustosRecordList

	/// <summary>
	/// RecordList type <code>RLFeriadosRecordList</code> that represents a record list of
	///  <code>Feriados</code>
	/// </summary>
	[Serializable()]
	public partial class RLFeriadosRecordList: GenericRecordList<RCFeriadosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFeriadosRecord GetElementDefaultValue() {
			return new RCFeriadosRecord("");
		}

		public T[] ToArray<T>(Func<RCFeriadosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFeriadosRecordList recordlist, Func<RCFeriadosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFeriadosRecordList(RCFeriadosRecord[] array) {
			RLFeriadosRecordList result = new RLFeriadosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFeriadosRecordList ToList<T>(T[] array, Func <T, RCFeriadosRecord> converter) {
			RLFeriadosRecordList result = new RLFeriadosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFeriadosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFeriadosRecord> converter) {
			RLFeriadosRecordList result = new RLFeriadosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFeriadosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFeriadosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFeriadosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFeriadosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(5, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFeriadosRecord> NewList() {
			return new RLFeriadosRecordList();
		}


	} // RLFeriadosRecordList

	/// <summary>
	/// RecordList type <code>RLObrasEtapasRecordList</code> that represents a record list of
	///  <code>ObrasEtapas</code>
	/// </summary>
	[Serializable()]
	public partial class RLObrasEtapasRecordList: GenericRecordList<RCObrasEtapasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCObrasEtapasRecord GetElementDefaultValue() {
			return new RCObrasEtapasRecord("");
		}

		public T[] ToArray<T>(Func<RCObrasEtapasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLObrasEtapasRecordList recordlist, Func<RCObrasEtapasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLObrasEtapasRecordList(RCObrasEtapasRecord[] array) {
			RLObrasEtapasRecordList result = new RLObrasEtapasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLObrasEtapasRecordList ToList<T>(T[] array, Func <T, RCObrasEtapasRecord> converter) {
			RLObrasEtapasRecordList result = new RLObrasEtapasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLObrasEtapasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCObrasEtapasRecord> converter) {
			RLObrasEtapasRecordList result = new RLObrasEtapasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLObrasEtapasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLObrasEtapasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(12, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCObrasEtapasRecord> NewList() {
			return new RLObrasEtapasRecordList();
		}


	} // RLObrasEtapasRecordList

	/// <summary>
	/// RecordList type <code>RLFuncionariosRecordList</code> that represents a record list of
	///  <code>Funcionarios</code>
	/// </summary>
	[Serializable()]
	public partial class RLFuncionariosRecordList: GenericRecordList<RCFuncionariosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFuncionariosRecord GetElementDefaultValue() {
			return new RCFuncionariosRecord("");
		}

		public T[] ToArray<T>(Func<RCFuncionariosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFuncionariosRecordList recordlist, Func<RCFuncionariosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFuncionariosRecordList(RCFuncionariosRecord[] array) {
			RLFuncionariosRecordList result = new RLFuncionariosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFuncionariosRecordList ToList<T>(T[] array, Func <T, RCFuncionariosRecord> converter) {
			RLFuncionariosRecordList result = new RLFuncionariosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFuncionariosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFuncionariosRecord> converter) {
			RLFuncionariosRecordList result = new RLFuncionariosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFuncionariosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFuncionariosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFuncionariosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFuncionariosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(2, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFuncionariosRecord> NewList() {
			return new RLFuncionariosRecordList();
		}


	} // RLFuncionariosRecordList

	/// <summary>
	/// RecordList type <code>RLMultas_GravidadeRecordList</code> that represents a record list of
	///  <code>Multas_Gravidade</code>
	/// </summary>
	[Serializable()]
	public partial class RLMultas_GravidadeRecordList: GenericRecordList<RCMultas_GravidadeRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCMultas_GravidadeRecord GetElementDefaultValue() {
			return new RCMultas_GravidadeRecord("");
		}

		public T[] ToArray<T>(Func<RCMultas_GravidadeRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLMultas_GravidadeRecordList recordlist, Func<RCMultas_GravidadeRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLMultas_GravidadeRecordList(RCMultas_GravidadeRecord[] array) {
			RLMultas_GravidadeRecordList result = new RLMultas_GravidadeRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLMultas_GravidadeRecordList ToList<T>(T[] array, Func <T, RCMultas_GravidadeRecord> converter) {
			RLMultas_GravidadeRecordList result = new RLMultas_GravidadeRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLMultas_GravidadeRecordList FromRestList<T>(RestList<T> restList, Func <T, RCMultas_GravidadeRecord> converter) {
			RLMultas_GravidadeRecordList result = new RLMultas_GravidadeRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLMultas_GravidadeRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLMultas_GravidadeRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLMultas_GravidadeRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLMultas_GravidadeRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(4, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCMultas_GravidadeRecord> NewList() {
			return new RLMultas_GravidadeRecordList();
		}


	} // RLMultas_GravidadeRecordList

	/// <summary>
	/// RecordList type <code>RLManutencoesRecordList</code> that represents a record list of
	///  <code>Manutencoes</code>
	/// </summary>
	[Serializable()]
	public partial class RLManutencoesRecordList: GenericRecordList<RCManutencoesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCManutencoesRecord GetElementDefaultValue() {
			return new RCManutencoesRecord("");
		}

		public T[] ToArray<T>(Func<RCManutencoesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLManutencoesRecordList recordlist, Func<RCManutencoesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLManutencoesRecordList(RCManutencoesRecord[] array) {
			RLManutencoesRecordList result = new RLManutencoesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLManutencoesRecordList ToList<T>(T[] array, Func <T, RCManutencoesRecord> converter) {
			RLManutencoesRecordList result = new RLManutencoesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLManutencoesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCManutencoesRecord> converter) {
			RLManutencoesRecordList result = new RLManutencoesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLManutencoesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLManutencoesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLManutencoesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLManutencoesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(9, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCManutencoesRecord> NewList() {
			return new RLManutencoesRecordList();
		}


	} // RLManutencoesRecordList

	/// <summary>
	/// RecordList type <code>RLUsuariosCentroCustoRecordList</code> that represents a record list of
	///  <code>UsuariosCentroCusto</code>
	/// </summary>
	[Serializable()]
	public partial class RLUsuariosCentroCustoRecordList: GenericRecordList<RCUsuariosCentroCustoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCUsuariosCentroCustoRecord GetElementDefaultValue() {
			return new RCUsuariosCentroCustoRecord("");
		}

		public T[] ToArray<T>(Func<RCUsuariosCentroCustoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLUsuariosCentroCustoRecordList recordlist, Func<RCUsuariosCentroCustoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLUsuariosCentroCustoRecordList(RCUsuariosCentroCustoRecord[] array) {
			RLUsuariosCentroCustoRecordList result = new RLUsuariosCentroCustoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLUsuariosCentroCustoRecordList ToList<T>(T[] array, Func <T, RCUsuariosCentroCustoRecord> converter) {
			RLUsuariosCentroCustoRecordList result = new RLUsuariosCentroCustoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLUsuariosCentroCustoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCUsuariosCentroCustoRecord> converter) {
			RLUsuariosCentroCustoRecordList result = new RLUsuariosCentroCustoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLUsuariosCentroCustoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosCentroCustoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosCentroCustoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLUsuariosCentroCustoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(3, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCUsuariosCentroCustoRecord> NewList() {
			return new RLUsuariosCentroCustoRecordList();
		}


	} // RLUsuariosCentroCustoRecordList

	/// <summary>
	/// RecordList type <code>RLObrasRecordList</code> that represents a record list of <code>Obras</code>
	/// </summary>
	[Serializable()]
	public partial class RLObrasRecordList: GenericRecordList<RCObrasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCObrasRecord GetElementDefaultValue() {
			return new RCObrasRecord("");
		}

		public T[] ToArray<T>(Func<RCObrasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLObrasRecordList recordlist, Func<RCObrasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLObrasRecordList(RCObrasRecord[] array) {
			RLObrasRecordList result = new RLObrasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLObrasRecordList ToList<T>(T[] array, Func <T, RCObrasRecord> converter) {
			RLObrasRecordList result = new RLObrasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLObrasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCObrasRecord> converter) {
			RLObrasRecordList result = new RLObrasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLObrasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLObrasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(7, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCObrasRecord> NewList() {
			return new RLObrasRecordList();
		}


	} // RLObrasRecordList

	/// <summary>
	/// RecordList type <code>RLFretes_ObrasRecordList</code> that represents a record list of
	///  <code>Fretes_Obras</code>
	/// </summary>
	[Serializable()]
	public partial class RLFretes_ObrasRecordList: GenericRecordList<RCFretes_ObrasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFretes_ObrasRecord GetElementDefaultValue() {
			return new RCFretes_ObrasRecord("");
		}

		public T[] ToArray<T>(Func<RCFretes_ObrasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFretes_ObrasRecordList recordlist, Func<RCFretes_ObrasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFretes_ObrasRecordList(RCFretes_ObrasRecord[] array) {
			RLFretes_ObrasRecordList result = new RLFretes_ObrasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFretes_ObrasRecordList ToList<T>(T[] array, Func <T, RCFretes_ObrasRecord> converter) {
			RLFretes_ObrasRecordList result = new RLFretes_ObrasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFretes_ObrasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFretes_ObrasRecord> converter) {
			RLFretes_ObrasRecordList result = new RLFretes_ObrasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFretes_ObrasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFretes_ObrasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFretes_ObrasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFretes_ObrasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(9, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFretes_ObrasRecord> NewList() {
			return new RLFretes_ObrasRecordList();
		}


	} // RLFretes_ObrasRecordList

	/// <summary>
	/// RecordList type <code>RLOrdemPagamentoItensRecordList</code> that represents a record list of
	///  <code>OrdemPagamentoItens</code>
	/// </summary>
	[Serializable()]
	public partial class RLOrdemPagamentoItensRecordList: GenericRecordList<RCOrdemPagamentoItensRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCOrdemPagamentoItensRecord GetElementDefaultValue() {
			return new RCOrdemPagamentoItensRecord("");
		}

		public T[] ToArray<T>(Func<RCOrdemPagamentoItensRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLOrdemPagamentoItensRecordList recordlist, Func<RCOrdemPagamentoItensRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLOrdemPagamentoItensRecordList(RCOrdemPagamentoItensRecord[] array) {
			RLOrdemPagamentoItensRecordList result = new RLOrdemPagamentoItensRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLOrdemPagamentoItensRecordList ToList<T>(T[] array, Func <T, RCOrdemPagamentoItensRecord> converter) {
			RLOrdemPagamentoItensRecordList result = new RLOrdemPagamentoItensRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLOrdemPagamentoItensRecordList FromRestList<T>(RestList<T> restList, Func <T, RCOrdemPagamentoItensRecord> converter) {
			RLOrdemPagamentoItensRecordList result = new RLOrdemPagamentoItensRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLOrdemPagamentoItensRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLOrdemPagamentoItensRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLOrdemPagamentoItensRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLOrdemPagamentoItensRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(17, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCOrdemPagamentoItensRecord> NewList() {
			return new RLOrdemPagamentoItensRecordList();
		}


	} // RLOrdemPagamentoItensRecordList

	/// <summary>
	/// RecordList type <code>RLClientes_ContasBancariasRecordList</code> that represents a record list of
	///  <code>Clientes_ContasBancarias</code>
	/// </summary>
	[Serializable()]
	public partial class RLClientes_ContasBancariasRecordList: GenericRecordList<RCClientes_ContasBancariasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCClientes_ContasBancariasRecord GetElementDefaultValue() {
			return new RCClientes_ContasBancariasRecord("");
		}

		public T[] ToArray<T>(Func<RCClientes_ContasBancariasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLClientes_ContasBancariasRecordList recordlist, Func<RCClientes_ContasBancariasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLClientes_ContasBancariasRecordList(RCClientes_ContasBancariasRecord[] array) {
			RLClientes_ContasBancariasRecordList result = new RLClientes_ContasBancariasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLClientes_ContasBancariasRecordList ToList<T>(T[] array, Func <T, RCClientes_ContasBancariasRecord> converter) {
			RLClientes_ContasBancariasRecordList result = new RLClientes_ContasBancariasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLClientes_ContasBancariasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCClientes_ContasBancariasRecord> converter) {
			RLClientes_ContasBancariasRecordList result = new RLClientes_ContasBancariasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLClientes_ContasBancariasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLClientes_ContasBancariasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLClientes_ContasBancariasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLClientes_ContasBancariasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(7, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCClientes_ContasBancariasRecord> NewList() {
			return new RLClientes_ContasBancariasRecordList();
		}


	} // RLClientes_ContasBancariasRecordList

	/// <summary>
	/// RecordList type <code>RLCentrosCustosRecordList</code> that represents a record list of
	///  <code>CentrosCustos</code>
	/// </summary>
	[Serializable()]
	public partial class RLCentrosCustosRecordList: GenericRecordList<RCCentrosCustosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCCentrosCustosRecord GetElementDefaultValue() {
			return new RCCentrosCustosRecord("");
		}

		public T[] ToArray<T>(Func<RCCentrosCustosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLCentrosCustosRecordList recordlist, Func<RCCentrosCustosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLCentrosCustosRecordList(RCCentrosCustosRecord[] array) {
			RLCentrosCustosRecordList result = new RLCentrosCustosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLCentrosCustosRecordList ToList<T>(T[] array, Func <T, RCCentrosCustosRecord> converter) {
			RLCentrosCustosRecordList result = new RLCentrosCustosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLCentrosCustosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCCentrosCustosRecord> converter) {
			RLCentrosCustosRecordList result = new RLCentrosCustosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLCentrosCustosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLCentrosCustosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLCentrosCustosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLCentrosCustosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(5, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCCentrosCustosRecord> NewList() {
			return new RLCentrosCustosRecordList();
		}


	} // RLCentrosCustosRecordList

	/// <summary>
	/// RecordList type <code>RLClientes_ContatosRecordList</code> that represents a record list of
	///  <code>Clientes_Contatos</code>
	/// </summary>
	[Serializable()]
	public partial class RLClientes_ContatosRecordList: GenericRecordList<RCClientes_ContatosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCClientes_ContatosRecord GetElementDefaultValue() {
			return new RCClientes_ContatosRecord("");
		}

		public T[] ToArray<T>(Func<RCClientes_ContatosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLClientes_ContatosRecordList recordlist, Func<RCClientes_ContatosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLClientes_ContatosRecordList(RCClientes_ContatosRecord[] array) {
			RLClientes_ContatosRecordList result = new RLClientes_ContatosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLClientes_ContatosRecordList ToList<T>(T[] array, Func <T, RCClientes_ContatosRecord> converter) {
			RLClientes_ContatosRecordList result = new RLClientes_ContatosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLClientes_ContatosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCClientes_ContatosRecord> converter) {
			RLClientes_ContatosRecordList result = new RLClientes_ContatosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLClientes_ContatosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLClientes_ContatosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLClientes_ContatosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLClientes_ContatosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(5, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCClientes_ContatosRecord> NewList() {
			return new RLClientes_ContatosRecordList();
		}


	} // RLClientes_ContatosRecordList

	/// <summary>
	/// RecordList type <code>RLFornecedores_ContatosRecordList</code> that represents a record list of
	///  <code>Fornecedores_Contatos</code>
	/// </summary>
	[Serializable()]
	public partial class RLFornecedores_ContatosRecordList: GenericRecordList<RCFornecedores_ContatosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCFornecedores_ContatosRecord GetElementDefaultValue() {
			return new RCFornecedores_ContatosRecord("");
		}

		public T[] ToArray<T>(Func<RCFornecedores_ContatosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLFornecedores_ContatosRecordList recordlist, Func<RCFornecedores_ContatosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLFornecedores_ContatosRecordList(RCFornecedores_ContatosRecord[] array) {
			RLFornecedores_ContatosRecordList result = new RLFornecedores_ContatosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLFornecedores_ContatosRecordList ToList<T>(T[] array, Func <T, RCFornecedores_ContatosRecord> converter) {
			RLFornecedores_ContatosRecordList result = new RLFornecedores_ContatosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLFornecedores_ContatosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCFornecedores_ContatosRecord> converter) {
			RLFornecedores_ContatosRecordList result = new RLFornecedores_ContatosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLFornecedores_ContatosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFornecedores_ContatosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLFornecedores_ContatosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLFornecedores_ContatosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(5, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCFornecedores_ContatosRecord> NewList() {
			return new RLFornecedores_ContatosRecordList();
		}


	} // RLFornecedores_ContatosRecordList

	/// <summary>
	/// RecordList type <code>RLObrasEtapas_GastosPrevistosRecordList</code> that represents a record list
	///  of <code>ObrasEtapas_GastosPrevistos</code>
	/// </summary>
	[Serializable()]
	public partial class RLObrasEtapas_GastosPrevistosRecordList: GenericRecordList<RCObrasEtapas_GastosPrevistosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCObrasEtapas_GastosPrevistosRecord GetElementDefaultValue() {
			return new RCObrasEtapas_GastosPrevistosRecord("");
		}

		public T[] ToArray<T>(Func<RCObrasEtapas_GastosPrevistosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLObrasEtapas_GastosPrevistosRecordList recordlist, Func<RCObrasEtapas_GastosPrevistosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLObrasEtapas_GastosPrevistosRecordList(RCObrasEtapas_GastosPrevistosRecord[] array) {
			RLObrasEtapas_GastosPrevistosRecordList result = new RLObrasEtapas_GastosPrevistosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLObrasEtapas_GastosPrevistosRecordList ToList<T>(T[] array, Func <T, RCObrasEtapas_GastosPrevistosRecord> converter) {
			RLObrasEtapas_GastosPrevistosRecordList result = new RLObrasEtapas_GastosPrevistosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLObrasEtapas_GastosPrevistosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCObrasEtapas_GastosPrevistosRecord> converter) {
			RLObrasEtapas_GastosPrevistosRecordList result = new RLObrasEtapas_GastosPrevistosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLObrasEtapas_GastosPrevistosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapas_GastosPrevistosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapas_GastosPrevistosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLObrasEtapas_GastosPrevistosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(7, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCObrasEtapas_GastosPrevistosRecord> NewList() {
			return new RLObrasEtapas_GastosPrevistosRecordList();
		}


	} // RLObrasEtapas_GastosPrevistosRecordList

	/// <summary>
	/// RecordList type <code>RLParametrizacoesRecordList</code> that represents a record list of
	///  <code>Parametrizacoes</code>
	/// </summary>
	[Serializable()]
	public partial class RLParametrizacoesRecordList: GenericRecordList<RCParametrizacoesRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCParametrizacoesRecord GetElementDefaultValue() {
			return new RCParametrizacoesRecord("");
		}

		public T[] ToArray<T>(Func<RCParametrizacoesRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLParametrizacoesRecordList recordlist, Func<RCParametrizacoesRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLParametrizacoesRecordList(RCParametrizacoesRecord[] array) {
			RLParametrizacoesRecordList result = new RLParametrizacoesRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLParametrizacoesRecordList ToList<T>(T[] array, Func <T, RCParametrizacoesRecord> converter) {
			RLParametrizacoesRecordList result = new RLParametrizacoesRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLParametrizacoesRecordList FromRestList<T>(RestList<T> restList, Func <T, RCParametrizacoesRecord> converter) {
			RLParametrizacoesRecordList result = new RLParametrizacoesRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLParametrizacoesRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLParametrizacoesRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLParametrizacoesRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLParametrizacoesRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(4, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCParametrizacoesRecord> NewList() {
			return new RLParametrizacoesRecordList();
		}


	} // RLParametrizacoesRecordList

	/// <summary>
	/// RecordList type <code>RLUsoVeiculosRecordList</code> that represents a record list of
	///  <code>UsoVeiculos</code>
	/// </summary>
	[Serializable()]
	public partial class RLUsoVeiculosRecordList: GenericRecordList<RCUsoVeiculosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCUsoVeiculosRecord GetElementDefaultValue() {
			return new RCUsoVeiculosRecord("");
		}

		public T[] ToArray<T>(Func<RCUsoVeiculosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLUsoVeiculosRecordList recordlist, Func<RCUsoVeiculosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLUsoVeiculosRecordList(RCUsoVeiculosRecord[] array) {
			RLUsoVeiculosRecordList result = new RLUsoVeiculosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLUsoVeiculosRecordList ToList<T>(T[] array, Func <T, RCUsoVeiculosRecord> converter) {
			RLUsoVeiculosRecordList result = new RLUsoVeiculosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLUsoVeiculosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCUsoVeiculosRecord> converter) {
			RLUsoVeiculosRecordList result = new RLUsoVeiculosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLUsoVeiculosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsoVeiculosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsoVeiculosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLUsoVeiculosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(7, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCUsoVeiculosRecord> NewList() {
			return new RLUsoVeiculosRecordList();
		}


	} // RLUsoVeiculosRecordList

	/// <summary>
	/// RecordList type <code>RLNotasFiscaisPrazoRecordList</code> that represents a record list of
	///  <code>NotasFiscaisPrazo</code>
	/// </summary>
	[Serializable()]
	public partial class RLNotasFiscaisPrazoRecordList: GenericRecordList<RCNotasFiscaisPrazoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCNotasFiscaisPrazoRecord GetElementDefaultValue() {
			return new RCNotasFiscaisPrazoRecord("");
		}

		public T[] ToArray<T>(Func<RCNotasFiscaisPrazoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLNotasFiscaisPrazoRecordList recordlist, Func<RCNotasFiscaisPrazoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLNotasFiscaisPrazoRecordList(RCNotasFiscaisPrazoRecord[] array) {
			RLNotasFiscaisPrazoRecordList result = new RLNotasFiscaisPrazoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLNotasFiscaisPrazoRecordList ToList<T>(T[] array, Func <T, RCNotasFiscaisPrazoRecord> converter) {
			RLNotasFiscaisPrazoRecordList result = new RLNotasFiscaisPrazoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLNotasFiscaisPrazoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCNotasFiscaisPrazoRecord> converter) {
			RLNotasFiscaisPrazoRecordList result = new RLNotasFiscaisPrazoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLNotasFiscaisPrazoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLNotasFiscaisPrazoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLNotasFiscaisPrazoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLNotasFiscaisPrazoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(2, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCNotasFiscaisPrazoRecord> NewList() {
			return new RLNotasFiscaisPrazoRecordList();
		}


	} // RLNotasFiscaisPrazoRecordList

	/// <summary>
	/// RecordList type <code>RLEmpilhadeiras_UsosRecordList</code> that represents a record list of
	///  <code>Empilhadeiras_Usos</code>
	/// </summary>
	[Serializable()]
	public partial class RLEmpilhadeiras_UsosRecordList: GenericRecordList<RCEmpilhadeiras_UsosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCEmpilhadeiras_UsosRecord GetElementDefaultValue() {
			return new RCEmpilhadeiras_UsosRecord("");
		}

		public T[] ToArray<T>(Func<RCEmpilhadeiras_UsosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLEmpilhadeiras_UsosRecordList recordlist, Func<RCEmpilhadeiras_UsosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLEmpilhadeiras_UsosRecordList(RCEmpilhadeiras_UsosRecord[] array) {
			RLEmpilhadeiras_UsosRecordList result = new RLEmpilhadeiras_UsosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLEmpilhadeiras_UsosRecordList ToList<T>(T[] array, Func <T, RCEmpilhadeiras_UsosRecord> converter) {
			RLEmpilhadeiras_UsosRecordList result = new RLEmpilhadeiras_UsosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLEmpilhadeiras_UsosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCEmpilhadeiras_UsosRecord> converter) {
			RLEmpilhadeiras_UsosRecordList result = new RLEmpilhadeiras_UsosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLEmpilhadeiras_UsosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpilhadeiras_UsosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLEmpilhadeiras_UsosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLEmpilhadeiras_UsosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(6, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCEmpilhadeiras_UsosRecord> NewList() {
			return new RLEmpilhadeiras_UsosRecordList();
		}


	} // RLEmpilhadeiras_UsosRecordList

	/// <summary>
	/// RecordList type <code>RLObrasEtapas_FollowUpRecordList</code> that represents a record list of
	///  <code>ObrasEtapas_FollowUp</code>
	/// </summary>
	[Serializable()]
	public partial class RLObrasEtapas_FollowUpRecordList: GenericRecordList<RCObrasEtapas_FollowUpRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCObrasEtapas_FollowUpRecord GetElementDefaultValue() {
			return new RCObrasEtapas_FollowUpRecord("");
		}

		public T[] ToArray<T>(Func<RCObrasEtapas_FollowUpRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLObrasEtapas_FollowUpRecordList recordlist, Func<RCObrasEtapas_FollowUpRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLObrasEtapas_FollowUpRecordList(RCObrasEtapas_FollowUpRecord[] array) {
			RLObrasEtapas_FollowUpRecordList result = new RLObrasEtapas_FollowUpRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLObrasEtapas_FollowUpRecordList ToList<T>(T[] array, Func <T, RCObrasEtapas_FollowUpRecord> converter) {
			RLObrasEtapas_FollowUpRecordList result = new RLObrasEtapas_FollowUpRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLObrasEtapas_FollowUpRecordList FromRestList<T>(RestList<T> restList, Func <T, RCObrasEtapas_FollowUpRecord> converter) {
			RLObrasEtapas_FollowUpRecordList result = new RLObrasEtapas_FollowUpRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLObrasEtapas_FollowUpRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapas_FollowUpRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLObrasEtapas_FollowUpRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLObrasEtapas_FollowUpRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(6, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCObrasEtapas_FollowUpRecord> NewList() {
			return new RLObrasEtapas_FollowUpRecordList();
		}


	} // RLObrasEtapas_FollowUpRecordList

	/// <summary>
	/// RecordList type <code>RLUsuariosRecordList</code> that represents a record list of
	///  <code>Usuarios</code>
	/// </summary>
	[Serializable()]
	public partial class RLUsuariosRecordList: GenericRecordList<RCUsuariosRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCUsuariosRecord GetElementDefaultValue() {
			return new RCUsuariosRecord("");
		}

		public T[] ToArray<T>(Func<RCUsuariosRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLUsuariosRecordList recordlist, Func<RCUsuariosRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLUsuariosRecordList(RCUsuariosRecord[] array) {
			RLUsuariosRecordList result = new RLUsuariosRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLUsuariosRecordList ToList<T>(T[] array, Func <T, RCUsuariosRecord> converter) {
			RLUsuariosRecordList result = new RLUsuariosRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLUsuariosRecordList FromRestList<T>(RestList<T> restList, Func <T, RCUsuariosRecord> converter) {
			RLUsuariosRecordList result = new RLUsuariosRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLUsuariosRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLUsuariosRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLUsuariosRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(8, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCUsuariosRecord> NewList() {
			return new RLUsuariosRecordList();
		}


	} // RLUsuariosRecordList

	/// <summary>
	/// RecordList type <code>RLOrdemPagamentoRecordList</code> that represents a record list of
	///  <code>OrdemPagamento</code>
	/// </summary>
	[Serializable()]
	public partial class RLOrdemPagamentoRecordList: GenericRecordList<RCOrdemPagamentoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCOrdemPagamentoRecord GetElementDefaultValue() {
			return new RCOrdemPagamentoRecord("");
		}

		public T[] ToArray<T>(Func<RCOrdemPagamentoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLOrdemPagamentoRecordList recordlist, Func<RCOrdemPagamentoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLOrdemPagamentoRecordList(RCOrdemPagamentoRecord[] array) {
			RLOrdemPagamentoRecordList result = new RLOrdemPagamentoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLOrdemPagamentoRecordList ToList<T>(T[] array, Func <T, RCOrdemPagamentoRecord> converter) {
			RLOrdemPagamentoRecordList result = new RLOrdemPagamentoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLOrdemPagamentoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCOrdemPagamentoRecord> converter) {
			RLOrdemPagamentoRecordList result = new RLOrdemPagamentoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLOrdemPagamentoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLOrdemPagamentoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLOrdemPagamentoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLOrdemPagamentoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(16, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCOrdemPagamentoRecord> NewList() {
			return new RLOrdemPagamentoRecordList();
		}


	} // RLOrdemPagamentoRecordList

	/// <summary>
	/// RecordList type <code>RLVW_Dashboard_EmpilhadeirasRecordList</code> that represents a record list
	///  of <code>VW_Dashboard_Empilhadeiras</code>
	/// </summary>
	[Serializable()]
	public partial class RLVW_Dashboard_EmpilhadeirasRecordList: GenericRecordList<RCVW_Dashboard_EmpilhadeirasRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCVW_Dashboard_EmpilhadeirasRecord GetElementDefaultValue() {
			return new RCVW_Dashboard_EmpilhadeirasRecord("");
		}

		public T[] ToArray<T>(Func<RCVW_Dashboard_EmpilhadeirasRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLVW_Dashboard_EmpilhadeirasRecordList recordlist, Func<RCVW_Dashboard_EmpilhadeirasRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLVW_Dashboard_EmpilhadeirasRecordList(RCVW_Dashboard_EmpilhadeirasRecord[] array) {
			RLVW_Dashboard_EmpilhadeirasRecordList result = new RLVW_Dashboard_EmpilhadeirasRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLVW_Dashboard_EmpilhadeirasRecordList ToList<T>(T[] array, Func <T, RCVW_Dashboard_EmpilhadeirasRecord> converter) {
			RLVW_Dashboard_EmpilhadeirasRecordList result = new RLVW_Dashboard_EmpilhadeirasRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLVW_Dashboard_EmpilhadeirasRecordList FromRestList<T>(RestList<T> restList, Func <T, RCVW_Dashboard_EmpilhadeirasRecord> converter) {
			RLVW_Dashboard_EmpilhadeirasRecordList result = new RLVW_Dashboard_EmpilhadeirasRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLVW_Dashboard_EmpilhadeirasRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_EmpilhadeirasRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_EmpilhadeirasRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLVW_Dashboard_EmpilhadeirasRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(2, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCVW_Dashboard_EmpilhadeirasRecord> NewList() {
			return new RLVW_Dashboard_EmpilhadeirasRecordList();
		}


	} // RLVW_Dashboard_EmpilhadeirasRecordList

	/// <summary>
	/// RecordList type <code>RLVW_Dashboard_GeradoresRecordList</code> that represents a record list of
	///  <code>VW_Dashboard_Geradores</code>
	/// </summary>
	[Serializable()]
	public partial class RLVW_Dashboard_GeradoresRecordList: GenericRecordList<RCVW_Dashboard_GeradoresRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCVW_Dashboard_GeradoresRecord GetElementDefaultValue() {
			return new RCVW_Dashboard_GeradoresRecord("");
		}

		public T[] ToArray<T>(Func<RCVW_Dashboard_GeradoresRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLVW_Dashboard_GeradoresRecordList recordlist, Func<RCVW_Dashboard_GeradoresRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLVW_Dashboard_GeradoresRecordList(RCVW_Dashboard_GeradoresRecord[] array) {
			RLVW_Dashboard_GeradoresRecordList result = new RLVW_Dashboard_GeradoresRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLVW_Dashboard_GeradoresRecordList ToList<T>(T[] array, Func <T, RCVW_Dashboard_GeradoresRecord> converter) {
			RLVW_Dashboard_GeradoresRecordList result = new RLVW_Dashboard_GeradoresRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLVW_Dashboard_GeradoresRecordList FromRestList<T>(RestList<T> restList, Func <T, RCVW_Dashboard_GeradoresRecord> converter) {
			RLVW_Dashboard_GeradoresRecordList result = new RLVW_Dashboard_GeradoresRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLVW_Dashboard_GeradoresRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_GeradoresRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_GeradoresRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLVW_Dashboard_GeradoresRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(2, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCVW_Dashboard_GeradoresRecord> NewList() {
			return new RLVW_Dashboard_GeradoresRecordList();
		}


	} // RLVW_Dashboard_GeradoresRecordList

	/// <summary>
	/// RecordList type <code>RLVW_Dashboard_OPsVencimentoRecordList</code> that represents a record list
	///  of <code>VW_Dashboard_OPsVencimento</code>
	/// </summary>
	[Serializable()]
	public partial class RLVW_Dashboard_OPsVencimentoRecordList: GenericRecordList<RCVW_Dashboard_OPsVencimentoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCVW_Dashboard_OPsVencimentoRecord GetElementDefaultValue() {
			return new RCVW_Dashboard_OPsVencimentoRecord("");
		}

		public T[] ToArray<T>(Func<RCVW_Dashboard_OPsVencimentoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLVW_Dashboard_OPsVencimentoRecordList recordlist, Func<RCVW_Dashboard_OPsVencimentoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLVW_Dashboard_OPsVencimentoRecordList(RCVW_Dashboard_OPsVencimentoRecord[] array) {
			RLVW_Dashboard_OPsVencimentoRecordList result = new RLVW_Dashboard_OPsVencimentoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLVW_Dashboard_OPsVencimentoRecordList ToList<T>(T[] array, Func <T, RCVW_Dashboard_OPsVencimentoRecord> converter) {
			RLVW_Dashboard_OPsVencimentoRecordList result = new RLVW_Dashboard_OPsVencimentoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLVW_Dashboard_OPsVencimentoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCVW_Dashboard_OPsVencimentoRecord> converter) {
			RLVW_Dashboard_OPsVencimentoRecordList result = new RLVW_Dashboard_OPsVencimentoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLVW_Dashboard_OPsVencimentoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_OPsVencimentoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_OPsVencimentoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLVW_Dashboard_OPsVencimentoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(4, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCVW_Dashboard_OPsVencimentoRecord> NewList() {
			return new RLVW_Dashboard_OPsVencimentoRecordList();
		}


	} // RLVW_Dashboard_OPsVencimentoRecordList

	/// <summary>
	/// RecordList type <code>RLVW_Dashboard_OPs_AnoRecordList</code> that represents a record list of
	///  <code>VW_Dashboard_OPs_Ano</code>
	/// </summary>
	[Serializable()]
	public partial class RLVW_Dashboard_OPs_AnoRecordList: GenericRecordList<RCVW_Dashboard_OPs_AnoRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCVW_Dashboard_OPs_AnoRecord GetElementDefaultValue() {
			return new RCVW_Dashboard_OPs_AnoRecord("");
		}

		public T[] ToArray<T>(Func<RCVW_Dashboard_OPs_AnoRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLVW_Dashboard_OPs_AnoRecordList recordlist, Func<RCVW_Dashboard_OPs_AnoRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLVW_Dashboard_OPs_AnoRecordList(RCVW_Dashboard_OPs_AnoRecord[] array) {
			RLVW_Dashboard_OPs_AnoRecordList result = new RLVW_Dashboard_OPs_AnoRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLVW_Dashboard_OPs_AnoRecordList ToList<T>(T[] array, Func <T, RCVW_Dashboard_OPs_AnoRecord> converter) {
			RLVW_Dashboard_OPs_AnoRecordList result = new RLVW_Dashboard_OPs_AnoRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLVW_Dashboard_OPs_AnoRecordList FromRestList<T>(RestList<T> restList, Func <T, RCVW_Dashboard_OPs_AnoRecord> converter) {
			RLVW_Dashboard_OPs_AnoRecordList result = new RLVW_Dashboard_OPs_AnoRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLVW_Dashboard_OPs_AnoRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_OPs_AnoRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_OPs_AnoRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLVW_Dashboard_OPs_AnoRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(4, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCVW_Dashboard_OPs_AnoRecord> NewList() {
			return new RLVW_Dashboard_OPs_AnoRecordList();
		}


	} // RLVW_Dashboard_OPs_AnoRecordList

	/// <summary>
	/// RecordList type <code>RLVW_Dashboard_OPs_CategoriaRecordList</code> that represents a record list
	///  of <code>VW_Dashboard_OPs_Categoria</code>
	/// </summary>
	[Serializable()]
	public partial class RLVW_Dashboard_OPs_CategoriaRecordList: GenericRecordList<RCVW_Dashboard_OPs_CategoriaRecord>, IEnumerable, IEnumerator, ISerializable {
		public static void EnsureInitialized() {}

		protected override RCVW_Dashboard_OPs_CategoriaRecord GetElementDefaultValue() {
			return new RCVW_Dashboard_OPs_CategoriaRecord("");
		}

		public T[] ToArray<T>(Func<RCVW_Dashboard_OPs_CategoriaRecord, T> converter) {
			return ToArray(this, converter);
		}

		public static T[] ToArray<T>(RLVW_Dashboard_OPs_CategoriaRecordList recordlist, Func<RCVW_Dashboard_OPs_CategoriaRecord, T> converter) {
			return InnerToArray(recordlist, converter);
		}
		public static implicit operator RLVW_Dashboard_OPs_CategoriaRecordList(RCVW_Dashboard_OPs_CategoriaRecord[] array) {
			RLVW_Dashboard_OPs_CategoriaRecordList result = new RLVW_Dashboard_OPs_CategoriaRecordList();
			result.InnerFromArray(array);
			return result;
		}

		public static RLVW_Dashboard_OPs_CategoriaRecordList ToList<T>(T[] array, Func <T, RCVW_Dashboard_OPs_CategoriaRecord> converter) {
			RLVW_Dashboard_OPs_CategoriaRecordList result = new RLVW_Dashboard_OPs_CategoriaRecordList();
			result.InnerFromArray(array, converter);
			return result;
		}

		public static RLVW_Dashboard_OPs_CategoriaRecordList FromRestList<T>(RestList<T> restList, Func <T, RCVW_Dashboard_OPs_CategoriaRecord> converter) {
			RLVW_Dashboard_OPs_CategoriaRecordList result = new RLVW_Dashboard_OPs_CategoriaRecordList();
			result.InnerFromRestList(restList, converter);
			return result;
		}
		/// <summary>
		/// Default Constructor
		/// </summary>
		public RLVW_Dashboard_OPs_CategoriaRecordList(): base() {
		}

		/// <summary>
		/// Constructor with transaction parameter
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_OPs_CategoriaRecordList(IDbTransaction trans): base(trans) {
		}

		/// <summary>
		/// Constructor with transaction parameter and alternate read method
		/// </summary>
		/// <param name="trans"> IDbTransaction Parameter</param>
		/// <param name="alternateReadDBMethod"> Alternate Read Method</param>
		[Obsolete("Use the Default Constructor and set the Transaction afterwards.")]
		public RLVW_Dashboard_OPs_CategoriaRecordList(IDbTransaction trans, ReadDBMethodDelegate alternateReadDBMethod): this(trans) {
			this.alternateReadDBMethod = alternateReadDBMethod;
		}

		/// <summary>
		/// Constructor declaration for serialization
		/// </summary>
		/// <param name="info"> SerializationInfo</param>
		/// <param name="context"> StreamingContext</param>
		public RLVW_Dashboard_OPs_CategoriaRecordList(SerializationInfo info, StreamingContext context): base(info, context) {
		}

		public override BitArray[] GetDefaultOptimizedValues() {
			BitArray[] def = new BitArray[1];
			def[0] = new BitArray(4, false);
			return def;
		}
		/// <summary>
		/// Create as new list
		/// </summary>
		/// <returns>The new record list</returns>
		protected override OSList<RCVW_Dashboard_OPs_CategoriaRecord> NewList() {
			return new RLVW_Dashboard_OPs_CategoriaRecordList();
		}


	} // RLVW_Dashboard_OPs_CategoriaRecordList
}
