using System;
using System.Collections;
using System.Data;
using System.Runtime.Serialization;
using System.Reflection;
using System.Xml;
using OutSystems.ObjectKeys;
using OutSystems.RuntimeCommon;
using OutSystems.HubEdition.RuntimePlatform;
using OutSystems.HubEdition.RuntimePlatform.Db;
using OutSystems.Internal.Db;

namespace OutSystems.NssBRGS_DB {

	/// <summary>
	/// Structure <code>RCFretes_PagamentosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFretes_PagamentosRecord: ISerializable, ITypedRecord<RCFretes_PagamentosRecord> {
		internal static readonly GlobalObjectKey IdFretes_Pagamentos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*RpktQF83TWM4JH31WvLV8Q");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Fretes_Pagamentos")]
		public ENFretes_PagamentosEntityRecord ssENFretes_Pagamentos;


		public static implicit operator ENFretes_PagamentosEntityRecord(RCFretes_PagamentosRecord r) {
			return r.ssENFretes_Pagamentos;
		}

		public static implicit operator RCFretes_PagamentosRecord(ENFretes_PagamentosEntityRecord r) {
			RCFretes_PagamentosRecord res = new RCFretes_PagamentosRecord(null);
			res.ssENFretes_Pagamentos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFretes_Pagamentos.ChangedAttributes = value;
			}
			get {
				return ssENFretes_Pagamentos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFretes_PagamentosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFretes_Pagamentos = new ENFretes_PagamentosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFretes_Pagamentos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFretes_Pagamentos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFretes_Pagamentos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFretes_Pagamentos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFretes_PagamentosRecord r) {
			this = r;
		}


		public static bool operator == (RCFretes_PagamentosRecord a, RCFretes_PagamentosRecord b) {
			if (a.ssENFretes_Pagamentos != b.ssENFretes_Pagamentos) return false;
			return true;
		}

		public static bool operator != (RCFretes_PagamentosRecord a, RCFretes_PagamentosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFretes_PagamentosRecord)) return false;
			return (this == (RCFretes_PagamentosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFretes_Pagamentos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFretes_PagamentosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFretes_Pagamentos = new ENFretes_PagamentosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFretes_Pagamentos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFretes_Pagamentos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFretes_Pagamentos = (ENFretes_PagamentosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFretes_Pagamentos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFretes_Pagamentos.InternalRecursiveSave();
		}


		public RCFretes_PagamentosRecord Duplicate() {
			RCFretes_PagamentosRecord t;
			t.ssENFretes_Pagamentos = (ENFretes_PagamentosEntityRecord) this.ssENFretes_Pagamentos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFretes_Pagamentos.ToXml(this, recordElem, "Fretes_Pagamentos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "fretes_pagamentos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Fretes_Pagamentos")) variable.Value = ssENFretes_Pagamentos; else variable.Optimized = true;
				variable.SetFieldName("fretes_pagamentos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFretes_Pagamentos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFretes_Pagamentos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFretes_Pagamentos) {
				return ssENFretes_Pagamentos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFretes_Pagamentos.FillFromOther((IRecord) other.AttributeGet(IdFretes_Pagamentos));
		}
		public bool IsDefault() {
			RCFretes_PagamentosRecord defaultStruct = new RCFretes_PagamentosRecord(null);
			if (this.ssENFretes_Pagamentos != defaultStruct.ssENFretes_Pagamentos) return false;
			return true;
		}
	} // RCFretes_PagamentosRecord

	/// <summary>
	/// Structure <code>RCCentrosCustos_DespesasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCCentrosCustos_DespesasRecord: ISerializable, ITypedRecord<RCCentrosCustos_DespesasRecord> {
		internal static readonly GlobalObjectKey IdCentrosCustos_Despesas = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*fNkEQpKs6yHa2ptPjaLMBw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("CentrosCustos_Despesas")]
		public ENCentrosCustos_DespesasEntityRecord ssENCentrosCustos_Despesas;


		public static implicit operator ENCentrosCustos_DespesasEntityRecord(RCCentrosCustos_DespesasRecord r) {
			return r.ssENCentrosCustos_Despesas;
		}

		public static implicit operator RCCentrosCustos_DespesasRecord(ENCentrosCustos_DespesasEntityRecord r) {
			RCCentrosCustos_DespesasRecord res = new RCCentrosCustos_DespesasRecord(null);
			res.ssENCentrosCustos_Despesas = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENCentrosCustos_Despesas.ChangedAttributes = value;
			}
			get {
				return ssENCentrosCustos_Despesas.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCCentrosCustos_DespesasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENCentrosCustos_Despesas = new ENCentrosCustos_DespesasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENCentrosCustos_Despesas.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENCentrosCustos_Despesas.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENCentrosCustos_Despesas.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENCentrosCustos_Despesas.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCCentrosCustos_DespesasRecord r) {
			this = r;
		}


		public static bool operator == (RCCentrosCustos_DespesasRecord a, RCCentrosCustos_DespesasRecord b) {
			if (a.ssENCentrosCustos_Despesas != b.ssENCentrosCustos_Despesas) return false;
			return true;
		}

		public static bool operator != (RCCentrosCustos_DespesasRecord a, RCCentrosCustos_DespesasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCCentrosCustos_DespesasRecord)) return false;
			return (this == (RCCentrosCustos_DespesasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENCentrosCustos_Despesas.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCCentrosCustos_DespesasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENCentrosCustos_Despesas = new ENCentrosCustos_DespesasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENCentrosCustos_Despesas", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENCentrosCustos_Despesas' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENCentrosCustos_Despesas = (ENCentrosCustos_DespesasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENCentrosCustos_Despesas.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENCentrosCustos_Despesas.InternalRecursiveSave();
		}


		public RCCentrosCustos_DespesasRecord Duplicate() {
			RCCentrosCustos_DespesasRecord t;
			t.ssENCentrosCustos_Despesas = (ENCentrosCustos_DespesasEntityRecord) this.ssENCentrosCustos_Despesas.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENCentrosCustos_Despesas.ToXml(this, recordElem, "CentrosCustos_Despesas", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "centroscustos_despesas") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".CentrosCustos_Despesas")) variable.Value = ssENCentrosCustos_Despesas; else variable.Optimized = true;
				variable.SetFieldName("centroscustos_despesas");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENCentrosCustos_Despesas.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENCentrosCustos_Despesas.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdCentrosCustos_Despesas) {
				return ssENCentrosCustos_Despesas;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENCentrosCustos_Despesas.FillFromOther((IRecord) other.AttributeGet(IdCentrosCustos_Despesas));
		}
		public bool IsDefault() {
			RCCentrosCustos_DespesasRecord defaultStruct = new RCCentrosCustos_DespesasRecord(null);
			if (this.ssENCentrosCustos_Despesas != defaultStruct.ssENCentrosCustos_Despesas) return false;
			return true;
		}
	} // RCCentrosCustos_DespesasRecord

	/// <summary>
	/// Structure <code>RCCategoriasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCCategoriasRecord: ISerializable, ITypedRecord<RCCategoriasRecord> {
		internal static readonly GlobalObjectKey IdCategorias = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*32wX0v_L+5u1GehRBbQz_A");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Categorias")]
		public ENCategoriasEntityRecord ssENCategorias;


		public static implicit operator ENCategoriasEntityRecord(RCCategoriasRecord r) {
			return r.ssENCategorias;
		}

		public static implicit operator RCCategoriasRecord(ENCategoriasEntityRecord r) {
			RCCategoriasRecord res = new RCCategoriasRecord(null);
			res.ssENCategorias = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENCategorias.ChangedAttributes = value;
			}
			get {
				return ssENCategorias.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCCategoriasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENCategorias = new ENCategoriasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENCategorias.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENCategorias.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENCategorias.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENCategorias.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCCategoriasRecord r) {
			this = r;
		}


		public static bool operator == (RCCategoriasRecord a, RCCategoriasRecord b) {
			if (a.ssENCategorias != b.ssENCategorias) return false;
			return true;
		}

		public static bool operator != (RCCategoriasRecord a, RCCategoriasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCCategoriasRecord)) return false;
			return (this == (RCCategoriasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENCategorias.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCCategoriasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENCategorias = new ENCategoriasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENCategorias", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENCategorias' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENCategorias = (ENCategoriasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENCategorias.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENCategorias.InternalRecursiveSave();
		}


		public RCCategoriasRecord Duplicate() {
			RCCategoriasRecord t;
			t.ssENCategorias = (ENCategoriasEntityRecord) this.ssENCategorias.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENCategorias.ToXml(this, recordElem, "Categorias", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "categorias") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Categorias")) variable.Value = ssENCategorias; else variable.Optimized = true;
				variable.SetFieldName("categorias");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENCategorias.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENCategorias.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdCategorias) {
				return ssENCategorias;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENCategorias.FillFromOther((IRecord) other.AttributeGet(IdCategorias));
		}
		public bool IsDefault() {
			RCCategoriasRecord defaultStruct = new RCCategoriasRecord(null);
			if (this.ssENCategorias != defaultStruct.ssENCategorias) return false;
			return true;
		}
	} // RCCategoriasRecord

	/// <summary>
	/// Structure <code>RCFasesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFasesRecord: ISerializable, ITypedRecord<RCFasesRecord> {
		internal static readonly GlobalObjectKey IdFases = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*ZihfZRRpXJncRuPr4KydEw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Fases")]
		public ENFasesEntityRecord ssENFases;


		public static implicit operator ENFasesEntityRecord(RCFasesRecord r) {
			return r.ssENFases;
		}

		public static implicit operator RCFasesRecord(ENFasesEntityRecord r) {
			RCFasesRecord res = new RCFasesRecord(null);
			res.ssENFases = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFases.ChangedAttributes = value;
			}
			get {
				return ssENFases.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFasesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFases = new ENFasesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFases.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFases.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFases.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFases.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFasesRecord r) {
			this = r;
		}


		public static bool operator == (RCFasesRecord a, RCFasesRecord b) {
			if (a.ssENFases != b.ssENFases) return false;
			return true;
		}

		public static bool operator != (RCFasesRecord a, RCFasesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFasesRecord)) return false;
			return (this == (RCFasesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFases.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFasesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFases = new ENFasesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFases", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFases' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFases = (ENFasesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFases.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFases.InternalRecursiveSave();
		}


		public RCFasesRecord Duplicate() {
			RCFasesRecord t;
			t.ssENFases = (ENFasesEntityRecord) this.ssENFases.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFases.ToXml(this, recordElem, "Fases", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "fases") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Fases")) variable.Value = ssENFases; else variable.Optimized = true;
				variable.SetFieldName("fases");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFases.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFases.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFases) {
				return ssENFases;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFases.FillFromOther((IRecord) other.AttributeGet(IdFases));
		}
		public bool IsDefault() {
			RCFasesRecord defaultStruct = new RCFasesRecord(null);
			if (this.ssENFases != defaultStruct.ssENFases) return false;
			return true;
		}
	} // RCFasesRecord

	/// <summary>
	/// Structure <code>RCMultasOcorrenciasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCMultasOcorrenciasRecord: ISerializable, ITypedRecord<RCMultasOcorrenciasRecord> {
		internal static readonly GlobalObjectKey IdMultasOcorrencias = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*__MPGdjG3gQaaS6LFqcwkg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("MultasOcorrencias")]
		public ENMultasOcorrenciasEntityRecord ssENMultasOcorrencias;


		public static implicit operator ENMultasOcorrenciasEntityRecord(RCMultasOcorrenciasRecord r) {
			return r.ssENMultasOcorrencias;
		}

		public static implicit operator RCMultasOcorrenciasRecord(ENMultasOcorrenciasEntityRecord r) {
			RCMultasOcorrenciasRecord res = new RCMultasOcorrenciasRecord(null);
			res.ssENMultasOcorrencias = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENMultasOcorrencias.ChangedAttributes = value;
			}
			get {
				return ssENMultasOcorrencias.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCMultasOcorrenciasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENMultasOcorrencias = new ENMultasOcorrenciasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(7, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENMultasOcorrencias.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENMultasOcorrencias.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENMultasOcorrencias.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENMultasOcorrencias.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCMultasOcorrenciasRecord r) {
			this = r;
		}


		public static bool operator == (RCMultasOcorrenciasRecord a, RCMultasOcorrenciasRecord b) {
			if (a.ssENMultasOcorrencias != b.ssENMultasOcorrencias) return false;
			return true;
		}

		public static bool operator != (RCMultasOcorrenciasRecord a, RCMultasOcorrenciasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCMultasOcorrenciasRecord)) return false;
			return (this == (RCMultasOcorrenciasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENMultasOcorrencias.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCMultasOcorrenciasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENMultasOcorrencias = new ENMultasOcorrenciasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENMultasOcorrencias", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENMultasOcorrencias' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENMultasOcorrencias = (ENMultasOcorrenciasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENMultasOcorrencias.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENMultasOcorrencias.InternalRecursiveSave();
		}


		public RCMultasOcorrenciasRecord Duplicate() {
			RCMultasOcorrenciasRecord t;
			t.ssENMultasOcorrencias = (ENMultasOcorrenciasEntityRecord) this.ssENMultasOcorrencias.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENMultasOcorrencias.ToXml(this, recordElem, "MultasOcorrencias", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "multasocorrencias") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".MultasOcorrencias")) variable.Value = ssENMultasOcorrencias; else variable.Optimized = true;
				variable.SetFieldName("multasocorrencias");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENMultasOcorrencias.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENMultasOcorrencias.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdMultasOcorrencias) {
				return ssENMultasOcorrencias;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENMultasOcorrencias.FillFromOther((IRecord) other.AttributeGet(IdMultasOcorrencias));
		}
		public bool IsDefault() {
			RCMultasOcorrenciasRecord defaultStruct = new RCMultasOcorrenciasRecord(null);
			if (this.ssENMultasOcorrencias != defaultStruct.ssENMultasOcorrencias) return false;
			return true;
		}
	} // RCMultasOcorrenciasRecord

	/// <summary>
	/// Structure <code>RCAtividadesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCAtividadesRecord: ISerializable, ITypedRecord<RCAtividadesRecord> {
		internal static readonly GlobalObjectKey IdAtividades = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*oQ0Sxlc_Q2aU747KmywJ0w");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Atividades")]
		public ENAtividadesEntityRecord ssENAtividades;


		public static implicit operator ENAtividadesEntityRecord(RCAtividadesRecord r) {
			return r.ssENAtividades;
		}

		public static implicit operator RCAtividadesRecord(ENAtividadesEntityRecord r) {
			RCAtividadesRecord res = new RCAtividadesRecord(null);
			res.ssENAtividades = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENAtividades.ChangedAttributes = value;
			}
			get {
				return ssENAtividades.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCAtividadesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENAtividades = new ENAtividadesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENAtividades.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENAtividades.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENAtividades.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENAtividades.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCAtividadesRecord r) {
			this = r;
		}


		public static bool operator == (RCAtividadesRecord a, RCAtividadesRecord b) {
			if (a.ssENAtividades != b.ssENAtividades) return false;
			return true;
		}

		public static bool operator != (RCAtividadesRecord a, RCAtividadesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCAtividadesRecord)) return false;
			return (this == (RCAtividadesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENAtividades.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCAtividadesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENAtividades = new ENAtividadesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENAtividades", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENAtividades' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENAtividades = (ENAtividadesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENAtividades.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENAtividades.InternalRecursiveSave();
		}


		public RCAtividadesRecord Duplicate() {
			RCAtividadesRecord t;
			t.ssENAtividades = (ENAtividadesEntityRecord) this.ssENAtividades.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENAtividades.ToXml(this, recordElem, "Atividades", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "atividades") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Atividades")) variable.Value = ssENAtividades; else variable.Optimized = true;
				variable.SetFieldName("atividades");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENAtividades.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENAtividades.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdAtividades) {
				return ssENAtividades;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENAtividades.FillFromOther((IRecord) other.AttributeGet(IdAtividades));
		}
		public bool IsDefault() {
			RCAtividadesRecord defaultStruct = new RCAtividadesRecord(null);
			if (this.ssENAtividades != defaultStruct.ssENAtividades) return false;
			return true;
		}
	} // RCAtividadesRecord

	/// <summary>
	/// Structure <code>RCDespesasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCDespesasRecord: ISerializable, ITypedRecord<RCDespesasRecord> {
		internal static readonly GlobalObjectKey IdDespesas = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*G9HH1Qq1QxIa06urF6c83Q");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Despesas")]
		public ENDespesasEntityRecord ssENDespesas;


		public static implicit operator ENDespesasEntityRecord(RCDespesasRecord r) {
			return r.ssENDespesas;
		}

		public static implicit operator RCDespesasRecord(ENDespesasEntityRecord r) {
			RCDespesasRecord res = new RCDespesasRecord(null);
			res.ssENDespesas = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENDespesas.ChangedAttributes = value;
			}
			get {
				return ssENDespesas.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCDespesasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENDespesas = new ENDespesasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(4, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENDespesas.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENDespesas.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENDespesas.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENDespesas.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCDespesasRecord r) {
			this = r;
		}


		public static bool operator == (RCDespesasRecord a, RCDespesasRecord b) {
			if (a.ssENDespesas != b.ssENDespesas) return false;
			return true;
		}

		public static bool operator != (RCDespesasRecord a, RCDespesasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCDespesasRecord)) return false;
			return (this == (RCDespesasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENDespesas.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCDespesasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENDespesas = new ENDespesasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENDespesas", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENDespesas' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENDespesas = (ENDespesasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENDespesas.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENDespesas.InternalRecursiveSave();
		}


		public RCDespesasRecord Duplicate() {
			RCDespesasRecord t;
			t.ssENDespesas = (ENDespesasEntityRecord) this.ssENDespesas.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENDespesas.ToXml(this, recordElem, "Despesas", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "despesas") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Despesas")) variable.Value = ssENDespesas; else variable.Optimized = true;
				variable.SetFieldName("despesas");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENDespesas.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENDespesas.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdDespesas) {
				return ssENDespesas;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENDespesas.FillFromOther((IRecord) other.AttributeGet(IdDespesas));
		}
		public bool IsDefault() {
			RCDespesasRecord defaultStruct = new RCDespesasRecord(null);
			if (this.ssENDespesas != defaultStruct.ssENDespesas) return false;
			return true;
		}
	} // RCDespesasRecord

	/// <summary>
	/// Structure <code>RCAbastecimentosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCAbastecimentosRecord: ISerializable, ITypedRecord<RCAbastecimentosRecord> {
		internal static readonly GlobalObjectKey IdAbastecimentos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*Wq67tcy91BNSU6B29tX5eA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Abastecimentos")]
		public ENAbastecimentosEntityRecord ssENAbastecimentos;


		public static implicit operator ENAbastecimentosEntityRecord(RCAbastecimentosRecord r) {
			return r.ssENAbastecimentos;
		}

		public static implicit operator RCAbastecimentosRecord(ENAbastecimentosEntityRecord r) {
			RCAbastecimentosRecord res = new RCAbastecimentosRecord(null);
			res.ssENAbastecimentos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENAbastecimentos.ChangedAttributes = value;
			}
			get {
				return ssENAbastecimentos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCAbastecimentosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENAbastecimentos = new ENAbastecimentosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(19, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENAbastecimentos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENAbastecimentos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENAbastecimentos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENAbastecimentos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCAbastecimentosRecord r) {
			this = r;
		}


		public static bool operator == (RCAbastecimentosRecord a, RCAbastecimentosRecord b) {
			if (a.ssENAbastecimentos != b.ssENAbastecimentos) return false;
			return true;
		}

		public static bool operator != (RCAbastecimentosRecord a, RCAbastecimentosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCAbastecimentosRecord)) return false;
			return (this == (RCAbastecimentosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENAbastecimentos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCAbastecimentosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENAbastecimentos = new ENAbastecimentosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENAbastecimentos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENAbastecimentos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENAbastecimentos = (ENAbastecimentosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENAbastecimentos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENAbastecimentos.InternalRecursiveSave();
		}


		public RCAbastecimentosRecord Duplicate() {
			RCAbastecimentosRecord t;
			t.ssENAbastecimentos = (ENAbastecimentosEntityRecord) this.ssENAbastecimentos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENAbastecimentos.ToXml(this, recordElem, "Abastecimentos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "abastecimentos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Abastecimentos")) variable.Value = ssENAbastecimentos; else variable.Optimized = true;
				variable.SetFieldName("abastecimentos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENAbastecimentos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENAbastecimentos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdAbastecimentos) {
				return ssENAbastecimentos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENAbastecimentos.FillFromOther((IRecord) other.AttributeGet(IdAbastecimentos));
		}
		public bool IsDefault() {
			RCAbastecimentosRecord defaultStruct = new RCAbastecimentosRecord(null);
			if (this.ssENAbastecimentos != defaultStruct.ssENAbastecimentos) return false;
			return true;
		}
	} // RCAbastecimentosRecord

	/// <summary>
	/// Structure <code>RCVeiculosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCVeiculosRecord: ISerializable, ITypedRecord<RCVeiculosRecord> {
		internal static readonly GlobalObjectKey IdVeiculos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*rM2cLDuNfNv97OgbUKweTg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Veiculos")]
		public ENVeiculosEntityRecord ssENVeiculos;


		public static implicit operator ENVeiculosEntityRecord(RCVeiculosRecord r) {
			return r.ssENVeiculos;
		}

		public static implicit operator RCVeiculosRecord(ENVeiculosEntityRecord r) {
			RCVeiculosRecord res = new RCVeiculosRecord(null);
			res.ssENVeiculos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENVeiculos.ChangedAttributes = value;
			}
			get {
				return ssENVeiculos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCVeiculosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENVeiculos = new ENVeiculosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(15, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENVeiculos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENVeiculos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENVeiculos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENVeiculos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCVeiculosRecord r) {
			this = r;
		}


		public static bool operator == (RCVeiculosRecord a, RCVeiculosRecord b) {
			if (a.ssENVeiculos != b.ssENVeiculos) return false;
			return true;
		}

		public static bool operator != (RCVeiculosRecord a, RCVeiculosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCVeiculosRecord)) return false;
			return (this == (RCVeiculosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENVeiculos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCVeiculosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENVeiculos = new ENVeiculosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENVeiculos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENVeiculos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENVeiculos = (ENVeiculosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENVeiculos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENVeiculos.InternalRecursiveSave();
		}


		public RCVeiculosRecord Duplicate() {
			RCVeiculosRecord t;
			t.ssENVeiculos = (ENVeiculosEntityRecord) this.ssENVeiculos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENVeiculos.ToXml(this, recordElem, "Veiculos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "veiculos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Veiculos")) variable.Value = ssENVeiculos; else variable.Optimized = true;
				variable.SetFieldName("veiculos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENVeiculos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENVeiculos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdVeiculos) {
				return ssENVeiculos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENVeiculos.FillFromOther((IRecord) other.AttributeGet(IdVeiculos));
		}
		public bool IsDefault() {
			RCVeiculosRecord defaultStruct = new RCVeiculosRecord(null);
			if (this.ssENVeiculos != defaultStruct.ssENVeiculos) return false;
			return true;
		}
	} // RCVeiculosRecord

	/// <summary>
	/// Structure <code>RCFornecedoresRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFornecedoresRecord: ISerializable, ITypedRecord<RCFornecedoresRecord> {
		internal static readonly GlobalObjectKey IdFornecedores = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*orpvIWf2Ji7zqOz3ZTz4bA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Fornecedores")]
		public ENFornecedoresEntityRecord ssENFornecedores;


		public static implicit operator ENFornecedoresEntityRecord(RCFornecedoresRecord r) {
			return r.ssENFornecedores;
		}

		public static implicit operator RCFornecedoresRecord(ENFornecedoresEntityRecord r) {
			RCFornecedoresRecord res = new RCFornecedoresRecord(null);
			res.ssENFornecedores = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFornecedores.ChangedAttributes = value;
			}
			get {
				return ssENFornecedores.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFornecedoresRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFornecedores = new ENFornecedoresEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(23, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFornecedores.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFornecedores.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFornecedores.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFornecedores.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFornecedoresRecord r) {
			this = r;
		}


		public static bool operator == (RCFornecedoresRecord a, RCFornecedoresRecord b) {
			if (a.ssENFornecedores != b.ssENFornecedores) return false;
			return true;
		}

		public static bool operator != (RCFornecedoresRecord a, RCFornecedoresRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFornecedoresRecord)) return false;
			return (this == (RCFornecedoresRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFornecedores.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFornecedoresRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFornecedores = new ENFornecedoresEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFornecedores", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFornecedores' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFornecedores = (ENFornecedoresEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFornecedores.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFornecedores.InternalRecursiveSave();
		}


		public RCFornecedoresRecord Duplicate() {
			RCFornecedoresRecord t;
			t.ssENFornecedores = (ENFornecedoresEntityRecord) this.ssENFornecedores.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFornecedores.ToXml(this, recordElem, "Fornecedores", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "fornecedores") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Fornecedores")) variable.Value = ssENFornecedores; else variable.Optimized = true;
				variable.SetFieldName("fornecedores");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFornecedores.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFornecedores.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFornecedores) {
				return ssENFornecedores;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFornecedores.FillFromOther((IRecord) other.AttributeGet(IdFornecedores));
		}
		public bool IsDefault() {
			RCFornecedoresRecord defaultStruct = new RCFornecedoresRecord(null);
			if (this.ssENFornecedores != defaultStruct.ssENFornecedores) return false;
			return true;
		}
	} // RCFornecedoresRecord

	/// <summary>
	/// Structure <code>RCUsuariosDespesasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCUsuariosDespesasRecord: ISerializable, ITypedRecord<RCUsuariosDespesasRecord> {
		internal static readonly GlobalObjectKey IdUsuariosDespesas = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*l2TLn+CINz76agpZE+JaZg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("UsuariosDespesas")]
		public ENUsuariosDespesasEntityRecord ssENUsuariosDespesas;


		public static implicit operator ENUsuariosDespesasEntityRecord(RCUsuariosDespesasRecord r) {
			return r.ssENUsuariosDespesas;
		}

		public static implicit operator RCUsuariosDespesasRecord(ENUsuariosDespesasEntityRecord r) {
			RCUsuariosDespesasRecord res = new RCUsuariosDespesasRecord(null);
			res.ssENUsuariosDespesas = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENUsuariosDespesas.ChangedAttributes = value;
			}
			get {
				return ssENUsuariosDespesas.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCUsuariosDespesasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENUsuariosDespesas = new ENUsuariosDespesasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENUsuariosDespesas.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENUsuariosDespesas.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENUsuariosDespesas.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENUsuariosDespesas.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCUsuariosDespesasRecord r) {
			this = r;
		}


		public static bool operator == (RCUsuariosDespesasRecord a, RCUsuariosDespesasRecord b) {
			if (a.ssENUsuariosDespesas != b.ssENUsuariosDespesas) return false;
			return true;
		}

		public static bool operator != (RCUsuariosDespesasRecord a, RCUsuariosDespesasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCUsuariosDespesasRecord)) return false;
			return (this == (RCUsuariosDespesasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENUsuariosDespesas.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCUsuariosDespesasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENUsuariosDespesas = new ENUsuariosDespesasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENUsuariosDespesas", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENUsuariosDespesas' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENUsuariosDespesas = (ENUsuariosDespesasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENUsuariosDespesas.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENUsuariosDespesas.InternalRecursiveSave();
		}


		public RCUsuariosDespesasRecord Duplicate() {
			RCUsuariosDespesasRecord t;
			t.ssENUsuariosDespesas = (ENUsuariosDespesasEntityRecord) this.ssENUsuariosDespesas.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENUsuariosDespesas.ToXml(this, recordElem, "UsuariosDespesas", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "usuariosdespesas") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UsuariosDespesas")) variable.Value = ssENUsuariosDespesas; else variable.Optimized = true;
				variable.SetFieldName("usuariosdespesas");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENUsuariosDespesas.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENUsuariosDespesas.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdUsuariosDespesas) {
				return ssENUsuariosDespesas;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENUsuariosDespesas.FillFromOther((IRecord) other.AttributeGet(IdUsuariosDespesas));
		}
		public bool IsDefault() {
			RCUsuariosDespesasRecord defaultStruct = new RCUsuariosDespesasRecord(null);
			if (this.ssENUsuariosDespesas != defaultStruct.ssENUsuariosDespesas) return false;
			return true;
		}
	} // RCUsuariosDespesasRecord

	/// <summary>
	/// Structure <code>RCNotasFiscaisItensRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCNotasFiscaisItensRecord: ISerializable, ITypedRecord<RCNotasFiscaisItensRecord> {
		internal static readonly GlobalObjectKey IdNotasFiscaisItens = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*JxJPpS_jyxwejzkuZ9nV2w");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("NotasFiscaisItens")]
		public ENNotasFiscaisItensEntityRecord ssENNotasFiscaisItens;


		public static implicit operator ENNotasFiscaisItensEntityRecord(RCNotasFiscaisItensRecord r) {
			return r.ssENNotasFiscaisItens;
		}

		public static implicit operator RCNotasFiscaisItensRecord(ENNotasFiscaisItensEntityRecord r) {
			RCNotasFiscaisItensRecord res = new RCNotasFiscaisItensRecord(null);
			res.ssENNotasFiscaisItens = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENNotasFiscaisItens.ChangedAttributes = value;
			}
			get {
				return ssENNotasFiscaisItens.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCNotasFiscaisItensRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENNotasFiscaisItens = new ENNotasFiscaisItensEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(6, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENNotasFiscaisItens.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENNotasFiscaisItens.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENNotasFiscaisItens.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENNotasFiscaisItens.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCNotasFiscaisItensRecord r) {
			this = r;
		}


		public static bool operator == (RCNotasFiscaisItensRecord a, RCNotasFiscaisItensRecord b) {
			if (a.ssENNotasFiscaisItens != b.ssENNotasFiscaisItens) return false;
			return true;
		}

		public static bool operator != (RCNotasFiscaisItensRecord a, RCNotasFiscaisItensRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCNotasFiscaisItensRecord)) return false;
			return (this == (RCNotasFiscaisItensRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENNotasFiscaisItens.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCNotasFiscaisItensRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENNotasFiscaisItens = new ENNotasFiscaisItensEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENNotasFiscaisItens", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENNotasFiscaisItens' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENNotasFiscaisItens = (ENNotasFiscaisItensEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENNotasFiscaisItens.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENNotasFiscaisItens.InternalRecursiveSave();
		}


		public RCNotasFiscaisItensRecord Duplicate() {
			RCNotasFiscaisItensRecord t;
			t.ssENNotasFiscaisItens = (ENNotasFiscaisItensEntityRecord) this.ssENNotasFiscaisItens.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENNotasFiscaisItens.ToXml(this, recordElem, "NotasFiscaisItens", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "notasfiscaisitens") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".NotasFiscaisItens")) variable.Value = ssENNotasFiscaisItens; else variable.Optimized = true;
				variable.SetFieldName("notasfiscaisitens");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENNotasFiscaisItens.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENNotasFiscaisItens.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdNotasFiscaisItens) {
				return ssENNotasFiscaisItens;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENNotasFiscaisItens.FillFromOther((IRecord) other.AttributeGet(IdNotasFiscaisItens));
		}
		public bool IsDefault() {
			RCNotasFiscaisItensRecord defaultStruct = new RCNotasFiscaisItensRecord(null);
			if (this.ssENNotasFiscaisItens != defaultStruct.ssENNotasFiscaisItens) return false;
			return true;
		}
	} // RCNotasFiscaisItensRecord

	/// <summary>
	/// Structure <code>RCMotoristasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCMotoristasRecord: ISerializable, ITypedRecord<RCMotoristasRecord> {
		internal static readonly GlobalObjectKey IdMotoristas = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*KpLi5V9B81nO1bzs3nb2xQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Motoristas")]
		public ENMotoristasEntityRecord ssENMotoristas;


		public static implicit operator ENMotoristasEntityRecord(RCMotoristasRecord r) {
			return r.ssENMotoristas;
		}

		public static implicit operator RCMotoristasRecord(ENMotoristasEntityRecord r) {
			RCMotoristasRecord res = new RCMotoristasRecord(null);
			res.ssENMotoristas = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENMotoristas.ChangedAttributes = value;
			}
			get {
				return ssENMotoristas.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCMotoristasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENMotoristas = new ENMotoristasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(7, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENMotoristas.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENMotoristas.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENMotoristas.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENMotoristas.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCMotoristasRecord r) {
			this = r;
		}


		public static bool operator == (RCMotoristasRecord a, RCMotoristasRecord b) {
			if (a.ssENMotoristas != b.ssENMotoristas) return false;
			return true;
		}

		public static bool operator != (RCMotoristasRecord a, RCMotoristasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCMotoristasRecord)) return false;
			return (this == (RCMotoristasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENMotoristas.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCMotoristasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENMotoristas = new ENMotoristasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENMotoristas", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENMotoristas' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENMotoristas = (ENMotoristasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENMotoristas.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENMotoristas.InternalRecursiveSave();
		}


		public RCMotoristasRecord Duplicate() {
			RCMotoristasRecord t;
			t.ssENMotoristas = (ENMotoristasEntityRecord) this.ssENMotoristas.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENMotoristas.ToXml(this, recordElem, "Motoristas", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "motoristas") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Motoristas")) variable.Value = ssENMotoristas; else variable.Optimized = true;
				variable.SetFieldName("motoristas");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENMotoristas.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENMotoristas.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdMotoristas) {
				return ssENMotoristas;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENMotoristas.FillFromOther((IRecord) other.AttributeGet(IdMotoristas));
		}
		public bool IsDefault() {
			RCMotoristasRecord defaultStruct = new RCMotoristasRecord(null);
			if (this.ssENMotoristas != defaultStruct.ssENMotoristas) return false;
			return true;
		}
	} // RCMotoristasRecord

	/// <summary>
	/// Structure <code>RCEmpresasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCEmpresasRecord: ISerializable, ITypedRecord<RCEmpresasRecord> {
		internal static readonly GlobalObjectKey IdEmpresas = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*OBo2Q76bUiqMykneoEvI_g");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Empresas")]
		public ENEmpresasEntityRecord ssENEmpresas;


		public static implicit operator ENEmpresasEntityRecord(RCEmpresasRecord r) {
			return r.ssENEmpresas;
		}

		public static implicit operator RCEmpresasRecord(ENEmpresasEntityRecord r) {
			RCEmpresasRecord res = new RCEmpresasRecord(null);
			res.ssENEmpresas = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENEmpresas.ChangedAttributes = value;
			}
			get {
				return ssENEmpresas.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCEmpresasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENEmpresas = new ENEmpresasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(12, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENEmpresas.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENEmpresas.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENEmpresas.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENEmpresas.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCEmpresasRecord r) {
			this = r;
		}


		public static bool operator == (RCEmpresasRecord a, RCEmpresasRecord b) {
			if (a.ssENEmpresas != b.ssENEmpresas) return false;
			return true;
		}

		public static bool operator != (RCEmpresasRecord a, RCEmpresasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCEmpresasRecord)) return false;
			return (this == (RCEmpresasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENEmpresas.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCEmpresasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENEmpresas = new ENEmpresasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENEmpresas", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENEmpresas' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENEmpresas = (ENEmpresasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENEmpresas.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENEmpresas.InternalRecursiveSave();
		}


		public RCEmpresasRecord Duplicate() {
			RCEmpresasRecord t;
			t.ssENEmpresas = (ENEmpresasEntityRecord) this.ssENEmpresas.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENEmpresas.ToXml(this, recordElem, "Empresas", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "empresas") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Empresas")) variable.Value = ssENEmpresas; else variable.Optimized = true;
				variable.SetFieldName("empresas");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENEmpresas.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENEmpresas.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdEmpresas) {
				return ssENEmpresas;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENEmpresas.FillFromOther((IRecord) other.AttributeGet(IdEmpresas));
		}
		public bool IsDefault() {
			RCEmpresasRecord defaultStruct = new RCEmpresasRecord(null);
			if (this.ssENEmpresas != defaultStruct.ssENEmpresas) return false;
			return true;
		}
	} // RCEmpresasRecord

	/// <summary>
	/// Structure <code>RCGeradores_ManutencoesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCGeradores_ManutencoesRecord: ISerializable, ITypedRecord<RCGeradores_ManutencoesRecord> {
		internal static readonly GlobalObjectKey IdGeradores_Manutencoes = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*HhZt_4B4Zb4FHuj_dUw1Bg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Geradores_Manutencoes")]
		public ENGeradores_ManutencoesEntityRecord ssENGeradores_Manutencoes;


		public static implicit operator ENGeradores_ManutencoesEntityRecord(RCGeradores_ManutencoesRecord r) {
			return r.ssENGeradores_Manutencoes;
		}

		public static implicit operator RCGeradores_ManutencoesRecord(ENGeradores_ManutencoesEntityRecord r) {
			RCGeradores_ManutencoesRecord res = new RCGeradores_ManutencoesRecord(null);
			res.ssENGeradores_Manutencoes = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENGeradores_Manutencoes.ChangedAttributes = value;
			}
			get {
				return ssENGeradores_Manutencoes.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCGeradores_ManutencoesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENGeradores_Manutencoes = new ENGeradores_ManutencoesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(5, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENGeradores_Manutencoes.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENGeradores_Manutencoes.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENGeradores_Manutencoes.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENGeradores_Manutencoes.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCGeradores_ManutencoesRecord r) {
			this = r;
		}


		public static bool operator == (RCGeradores_ManutencoesRecord a, RCGeradores_ManutencoesRecord b) {
			if (a.ssENGeradores_Manutencoes != b.ssENGeradores_Manutencoes) return false;
			return true;
		}

		public static bool operator != (RCGeradores_ManutencoesRecord a, RCGeradores_ManutencoesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCGeradores_ManutencoesRecord)) return false;
			return (this == (RCGeradores_ManutencoesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENGeradores_Manutencoes.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCGeradores_ManutencoesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENGeradores_Manutencoes = new ENGeradores_ManutencoesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENGeradores_Manutencoes", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENGeradores_Manutencoes' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENGeradores_Manutencoes = (ENGeradores_ManutencoesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENGeradores_Manutencoes.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENGeradores_Manutencoes.InternalRecursiveSave();
		}


		public RCGeradores_ManutencoesRecord Duplicate() {
			RCGeradores_ManutencoesRecord t;
			t.ssENGeradores_Manutencoes = (ENGeradores_ManutencoesEntityRecord) this.ssENGeradores_Manutencoes.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENGeradores_Manutencoes.ToXml(this, recordElem, "Geradores_Manutencoes", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "geradores_manutencoes") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Geradores_Manutencoes")) variable.Value = ssENGeradores_Manutencoes; else variable.Optimized = true;
				variable.SetFieldName("geradores_manutencoes");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENGeradores_Manutencoes.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENGeradores_Manutencoes.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdGeradores_Manutencoes) {
				return ssENGeradores_Manutencoes;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENGeradores_Manutencoes.FillFromOther((IRecord) other.AttributeGet(IdGeradores_Manutencoes));
		}
		public bool IsDefault() {
			RCGeradores_ManutencoesRecord defaultStruct = new RCGeradores_ManutencoesRecord(null);
			if (this.ssENGeradores_Manutencoes != defaultStruct.ssENGeradores_Manutencoes) return false;
			return true;
		}
	} // RCGeradores_ManutencoesRecord

	/// <summary>
	/// Structure <code>RCClientesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCClientesRecord: ISerializable, ITypedRecord<RCClientesRecord> {
		internal static readonly GlobalObjectKey IdClientes = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*lDX+uvqbqzFqyFmbrd2+Lw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Clientes")]
		public ENClientesEntityRecord ssENClientes;


		public static implicit operator ENClientesEntityRecord(RCClientesRecord r) {
			return r.ssENClientes;
		}

		public static implicit operator RCClientesRecord(ENClientesEntityRecord r) {
			RCClientesRecord res = new RCClientesRecord(null);
			res.ssENClientes = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENClientes.ChangedAttributes = value;
			}
			get {
				return ssENClientes.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCClientesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENClientes = new ENClientesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(23, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENClientes.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENClientes.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENClientes.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENClientes.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCClientesRecord r) {
			this = r;
		}


		public static bool operator == (RCClientesRecord a, RCClientesRecord b) {
			if (a.ssENClientes != b.ssENClientes) return false;
			return true;
		}

		public static bool operator != (RCClientesRecord a, RCClientesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCClientesRecord)) return false;
			return (this == (RCClientesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENClientes.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCClientesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENClientes = new ENClientesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENClientes", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENClientes' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENClientes = (ENClientesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENClientes.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENClientes.InternalRecursiveSave();
		}


		public RCClientesRecord Duplicate() {
			RCClientesRecord t;
			t.ssENClientes = (ENClientesEntityRecord) this.ssENClientes.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENClientes.ToXml(this, recordElem, "Clientes", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "clientes") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Clientes")) variable.Value = ssENClientes; else variable.Optimized = true;
				variable.SetFieldName("clientes");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENClientes.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENClientes.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdClientes) {
				return ssENClientes;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENClientes.FillFromOther((IRecord) other.AttributeGet(IdClientes));
		}
		public bool IsDefault() {
			RCClientesRecord defaultStruct = new RCClientesRecord(null);
			if (this.ssENClientes != defaultStruct.ssENClientes) return false;
			return true;
		}
	} // RCClientesRecord

	/// <summary>
	/// Structure <code>RCObrasEtapas_FasesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCObrasEtapas_FasesRecord: ISerializable, ITypedRecord<RCObrasEtapas_FasesRecord> {
		internal static readonly GlobalObjectKey IdObrasEtapas_Fases = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*eIeA3kHFCivtK+uzcC5ggQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ObrasEtapas_Fases")]
		public ENObrasEtapas_FasesEntityRecord ssENObrasEtapas_Fases;


		public static implicit operator ENObrasEtapas_FasesEntityRecord(RCObrasEtapas_FasesRecord r) {
			return r.ssENObrasEtapas_Fases;
		}

		public static implicit operator RCObrasEtapas_FasesRecord(ENObrasEtapas_FasesEntityRecord r) {
			RCObrasEtapas_FasesRecord res = new RCObrasEtapas_FasesRecord(null);
			res.ssENObrasEtapas_Fases = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENObrasEtapas_Fases.ChangedAttributes = value;
			}
			get {
				return ssENObrasEtapas_Fases.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCObrasEtapas_FasesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENObrasEtapas_Fases = new ENObrasEtapas_FasesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(6, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENObrasEtapas_Fases.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENObrasEtapas_Fases.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENObrasEtapas_Fases.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENObrasEtapas_Fases.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCObrasEtapas_FasesRecord r) {
			this = r;
		}


		public static bool operator == (RCObrasEtapas_FasesRecord a, RCObrasEtapas_FasesRecord b) {
			if (a.ssENObrasEtapas_Fases != b.ssENObrasEtapas_Fases) return false;
			return true;
		}

		public static bool operator != (RCObrasEtapas_FasesRecord a, RCObrasEtapas_FasesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCObrasEtapas_FasesRecord)) return false;
			return (this == (RCObrasEtapas_FasesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENObrasEtapas_Fases.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCObrasEtapas_FasesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENObrasEtapas_Fases = new ENObrasEtapas_FasesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENObrasEtapas_Fases", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENObrasEtapas_Fases' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENObrasEtapas_Fases = (ENObrasEtapas_FasesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENObrasEtapas_Fases.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENObrasEtapas_Fases.InternalRecursiveSave();
		}


		public RCObrasEtapas_FasesRecord Duplicate() {
			RCObrasEtapas_FasesRecord t;
			t.ssENObrasEtapas_Fases = (ENObrasEtapas_FasesEntityRecord) this.ssENObrasEtapas_Fases.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENObrasEtapas_Fases.ToXml(this, recordElem, "ObrasEtapas_Fases", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "obrasetapas_fases") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ObrasEtapas_Fases")) variable.Value = ssENObrasEtapas_Fases; else variable.Optimized = true;
				variable.SetFieldName("obrasetapas_fases");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas_Fases.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas_Fases.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdObrasEtapas_Fases) {
				return ssENObrasEtapas_Fases;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENObrasEtapas_Fases.FillFromOther((IRecord) other.AttributeGet(IdObrasEtapas_Fases));
		}
		public bool IsDefault() {
			RCObrasEtapas_FasesRecord defaultStruct = new RCObrasEtapas_FasesRecord(null);
			if (this.ssENObrasEtapas_Fases != defaultStruct.ssENObrasEtapas_Fases) return false;
			return true;
		}
	} // RCObrasEtapas_FasesRecord

	/// <summary>
	/// Structure <code>RCGeradores_UsosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCGeradores_UsosRecord: ISerializable, ITypedRecord<RCGeradores_UsosRecord> {
		internal static readonly GlobalObjectKey IdGeradores_Usos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*z+hrez95SFrMf7vbScLbxA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Geradores_Usos")]
		public ENGeradores_UsosEntityRecord ssENGeradores_Usos;


		public static implicit operator ENGeradores_UsosEntityRecord(RCGeradores_UsosRecord r) {
			return r.ssENGeradores_Usos;
		}

		public static implicit operator RCGeradores_UsosRecord(ENGeradores_UsosEntityRecord r) {
			RCGeradores_UsosRecord res = new RCGeradores_UsosRecord(null);
			res.ssENGeradores_Usos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENGeradores_Usos.ChangedAttributes = value;
			}
			get {
				return ssENGeradores_Usos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCGeradores_UsosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENGeradores_Usos = new ENGeradores_UsosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(6, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENGeradores_Usos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENGeradores_Usos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENGeradores_Usos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENGeradores_Usos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCGeradores_UsosRecord r) {
			this = r;
		}


		public static bool operator == (RCGeradores_UsosRecord a, RCGeradores_UsosRecord b) {
			if (a.ssENGeradores_Usos != b.ssENGeradores_Usos) return false;
			return true;
		}

		public static bool operator != (RCGeradores_UsosRecord a, RCGeradores_UsosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCGeradores_UsosRecord)) return false;
			return (this == (RCGeradores_UsosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENGeradores_Usos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCGeradores_UsosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENGeradores_Usos = new ENGeradores_UsosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENGeradores_Usos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENGeradores_Usos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENGeradores_Usos = (ENGeradores_UsosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENGeradores_Usos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENGeradores_Usos.InternalRecursiveSave();
		}


		public RCGeradores_UsosRecord Duplicate() {
			RCGeradores_UsosRecord t;
			t.ssENGeradores_Usos = (ENGeradores_UsosEntityRecord) this.ssENGeradores_Usos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENGeradores_Usos.ToXml(this, recordElem, "Geradores_Usos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "geradores_usos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Geradores_Usos")) variable.Value = ssENGeradores_Usos; else variable.Optimized = true;
				variable.SetFieldName("geradores_usos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENGeradores_Usos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENGeradores_Usos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdGeradores_Usos) {
				return ssENGeradores_Usos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENGeradores_Usos.FillFromOther((IRecord) other.AttributeGet(IdGeradores_Usos));
		}
		public bool IsDefault() {
			RCGeradores_UsosRecord defaultStruct = new RCGeradores_UsosRecord(null);
			if (this.ssENGeradores_Usos != defaultStruct.ssENGeradores_Usos) return false;
			return true;
		}
	} // RCGeradores_UsosRecord

	/// <summary>
	/// Structure <code>RCUsuariosUENRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCUsuariosUENRecord: ISerializable, ITypedRecord<RCUsuariosUENRecord> {
		internal static readonly GlobalObjectKey IdUsuariosUEN = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*YwRw_RePUlPh0L80rdU_Cw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("UsuariosUEN")]
		public ENUsuariosUENEntityRecord ssENUsuariosUEN;


		public static implicit operator ENUsuariosUENEntityRecord(RCUsuariosUENRecord r) {
			return r.ssENUsuariosUEN;
		}

		public static implicit operator RCUsuariosUENRecord(ENUsuariosUENEntityRecord r) {
			RCUsuariosUENRecord res = new RCUsuariosUENRecord(null);
			res.ssENUsuariosUEN = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENUsuariosUEN.ChangedAttributes = value;
			}
			get {
				return ssENUsuariosUEN.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCUsuariosUENRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENUsuariosUEN = new ENUsuariosUENEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENUsuariosUEN.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENUsuariosUEN.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENUsuariosUEN.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENUsuariosUEN.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCUsuariosUENRecord r) {
			this = r;
		}


		public static bool operator == (RCUsuariosUENRecord a, RCUsuariosUENRecord b) {
			if (a.ssENUsuariosUEN != b.ssENUsuariosUEN) return false;
			return true;
		}

		public static bool operator != (RCUsuariosUENRecord a, RCUsuariosUENRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCUsuariosUENRecord)) return false;
			return (this == (RCUsuariosUENRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENUsuariosUEN.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCUsuariosUENRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENUsuariosUEN = new ENUsuariosUENEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENUsuariosUEN", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENUsuariosUEN' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENUsuariosUEN = (ENUsuariosUENEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENUsuariosUEN.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENUsuariosUEN.InternalRecursiveSave();
		}


		public RCUsuariosUENRecord Duplicate() {
			RCUsuariosUENRecord t;
			t.ssENUsuariosUEN = (ENUsuariosUENEntityRecord) this.ssENUsuariosUEN.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENUsuariosUEN.ToXml(this, recordElem, "UsuariosUEN", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "usuariosuen") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UsuariosUEN")) variable.Value = ssENUsuariosUEN; else variable.Optimized = true;
				variable.SetFieldName("usuariosuen");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENUsuariosUEN.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENUsuariosUEN.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdUsuariosUEN) {
				return ssENUsuariosUEN;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENUsuariosUEN.FillFromOther((IRecord) other.AttributeGet(IdUsuariosUEN));
		}
		public bool IsDefault() {
			RCUsuariosUENRecord defaultStruct = new RCUsuariosUENRecord(null);
			if (this.ssENUsuariosUEN != defaultStruct.ssENUsuariosUEN) return false;
			return true;
		}
	} // RCUsuariosUENRecord

	/// <summary>
	/// Structure <code>RCUENRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCUENRecord: ISerializable, ITypedRecord<RCUENRecord> {
		internal static readonly GlobalObjectKey IdUEN = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*eZBzsvkSz5MSKivicbdEIA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("UEN")]
		public ENUENEntityRecord ssENUEN;


		public static implicit operator ENUENEntityRecord(RCUENRecord r) {
			return r.ssENUEN;
		}

		public static implicit operator RCUENRecord(ENUENEntityRecord r) {
			RCUENRecord res = new RCUENRecord(null);
			res.ssENUEN = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENUEN.ChangedAttributes = value;
			}
			get {
				return ssENUEN.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCUENRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENUEN = new ENUENEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(4, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENUEN.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENUEN.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENUEN.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENUEN.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCUENRecord r) {
			this = r;
		}


		public static bool operator == (RCUENRecord a, RCUENRecord b) {
			if (a.ssENUEN != b.ssENUEN) return false;
			return true;
		}

		public static bool operator != (RCUENRecord a, RCUENRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCUENRecord)) return false;
			return (this == (RCUENRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENUEN.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCUENRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENUEN = new ENUENEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENUEN", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENUEN' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENUEN = (ENUENEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENUEN.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENUEN.InternalRecursiveSave();
		}


		public RCUENRecord Duplicate() {
			RCUENRecord t;
			t.ssENUEN = (ENUENEntityRecord) this.ssENUEN.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENUEN.ToXml(this, recordElem, "UEN", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "uen") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UEN")) variable.Value = ssENUEN; else variable.Optimized = true;
				variable.SetFieldName("uen");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENUEN.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENUEN.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdUEN) {
				return ssENUEN;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENUEN.FillFromOther((IRecord) other.AttributeGet(IdUEN));
		}
		public bool IsDefault() {
			RCUENRecord defaultStruct = new RCUENRecord(null);
			if (this.ssENUEN != defaultStruct.ssENUEN) return false;
			return true;
		}
	} // RCUENRecord

	/// <summary>
	/// Structure <code>RCMultasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCMultasRecord: ISerializable, ITypedRecord<RCMultasRecord> {
		internal static readonly GlobalObjectKey IdMultas = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*8SJ5MT5zu4puHPwxSAt4Gg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Multas")]
		public ENMultasEntityRecord ssENMultas;


		public static implicit operator ENMultasEntityRecord(RCMultasRecord r) {
			return r.ssENMultas;
		}

		public static implicit operator RCMultasRecord(ENMultasEntityRecord r) {
			RCMultasRecord res = new RCMultasRecord(null);
			res.ssENMultas = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENMultas.ChangedAttributes = value;
			}
			get {
				return ssENMultas.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCMultasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENMultas = new ENMultasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(9, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENMultas.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENMultas.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENMultas.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENMultas.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCMultasRecord r) {
			this = r;
		}


		public static bool operator == (RCMultasRecord a, RCMultasRecord b) {
			if (a.ssENMultas != b.ssENMultas) return false;
			return true;
		}

		public static bool operator != (RCMultasRecord a, RCMultasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCMultasRecord)) return false;
			return (this == (RCMultasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENMultas.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCMultasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENMultas = new ENMultasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENMultas", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENMultas' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENMultas = (ENMultasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENMultas.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENMultas.InternalRecursiveSave();
		}


		public RCMultasRecord Duplicate() {
			RCMultasRecord t;
			t.ssENMultas = (ENMultasEntityRecord) this.ssENMultas.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENMultas.ToXml(this, recordElem, "Multas", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "multas") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Multas")) variable.Value = ssENMultas; else variable.Optimized = true;
				variable.SetFieldName("multas");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENMultas.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENMultas.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdMultas) {
				return ssENMultas;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENMultas.FillFromOther((IRecord) other.AttributeGet(IdMultas));
		}
		public bool IsDefault() {
			RCMultasRecord defaultStruct = new RCMultasRecord(null);
			if (this.ssENMultas != defaultStruct.ssENMultas) return false;
			return true;
		}
	} // RCMultasRecord

	/// <summary>
	/// Structure <code>RCObrasEtapas_GastosRealizadosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCObrasEtapas_GastosRealizadosRecord: ISerializable, ITypedRecord<RCObrasEtapas_GastosRealizadosRecord> {
		internal static readonly GlobalObjectKey IdObrasEtapas_GastosRealizados = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*qIAJ+8s_HEsKqRcvms6HZA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ObrasEtapas_GastosRealizados")]
		public ENObrasEtapas_GastosRealizadosEntityRecord ssENObrasEtapas_GastosRealizados;


		public static implicit operator ENObrasEtapas_GastosRealizadosEntityRecord(RCObrasEtapas_GastosRealizadosRecord r) {
			return r.ssENObrasEtapas_GastosRealizados;
		}

		public static implicit operator RCObrasEtapas_GastosRealizadosRecord(ENObrasEtapas_GastosRealizadosEntityRecord r) {
			RCObrasEtapas_GastosRealizadosRecord res = new RCObrasEtapas_GastosRealizadosRecord(null);
			res.ssENObrasEtapas_GastosRealizados = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENObrasEtapas_GastosRealizados.ChangedAttributes = value;
			}
			get {
				return ssENObrasEtapas_GastosRealizados.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCObrasEtapas_GastosRealizadosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENObrasEtapas_GastosRealizados = new ENObrasEtapas_GastosRealizadosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(10, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENObrasEtapas_GastosRealizados.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENObrasEtapas_GastosRealizados.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENObrasEtapas_GastosRealizados.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENObrasEtapas_GastosRealizados.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCObrasEtapas_GastosRealizadosRecord r) {
			this = r;
		}


		public static bool operator == (RCObrasEtapas_GastosRealizadosRecord a, RCObrasEtapas_GastosRealizadosRecord b) {
			if (a.ssENObrasEtapas_GastosRealizados != b.ssENObrasEtapas_GastosRealizados) return false;
			return true;
		}

		public static bool operator != (RCObrasEtapas_GastosRealizadosRecord a, RCObrasEtapas_GastosRealizadosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCObrasEtapas_GastosRealizadosRecord)) return false;
			return (this == (RCObrasEtapas_GastosRealizadosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENObrasEtapas_GastosRealizados.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCObrasEtapas_GastosRealizadosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENObrasEtapas_GastosRealizados = new ENObrasEtapas_GastosRealizadosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENObrasEtapas_GastosRealizados", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENObrasEtapas_GastosRealizados' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENObrasEtapas_GastosRealizados = (ENObrasEtapas_GastosRealizadosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENObrasEtapas_GastosRealizados.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENObrasEtapas_GastosRealizados.InternalRecursiveSave();
		}


		public RCObrasEtapas_GastosRealizadosRecord Duplicate() {
			RCObrasEtapas_GastosRealizadosRecord t;
			t.ssENObrasEtapas_GastosRealizados = (ENObrasEtapas_GastosRealizadosEntityRecord) this.ssENObrasEtapas_GastosRealizados.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENObrasEtapas_GastosRealizados.ToXml(this, recordElem, "ObrasEtapas_GastosRealizados", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "obrasetapas_gastosrealizados") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ObrasEtapas_GastosRealizados")) variable.Value = ssENObrasEtapas_GastosRealizados; else variable.Optimized = true;
				variable.SetFieldName("obrasetapas_gastosrealizados");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas_GastosRealizados.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas_GastosRealizados.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdObrasEtapas_GastosRealizados) {
				return ssENObrasEtapas_GastosRealizados;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENObrasEtapas_GastosRealizados.FillFromOther((IRecord) other.AttributeGet(IdObrasEtapas_GastosRealizados));
		}
		public bool IsDefault() {
			RCObrasEtapas_GastosRealizadosRecord defaultStruct = new RCObrasEtapas_GastosRealizadosRecord(null);
			if (this.ssENObrasEtapas_GastosRealizados != defaultStruct.ssENObrasEtapas_GastosRealizados) return false;
			return true;
		}
	} // RCObrasEtapas_GastosRealizadosRecord

	/// <summary>
	/// Structure <code>RCFretesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFretesRecord: ISerializable, ITypedRecord<RCFretesRecord> {
		internal static readonly GlobalObjectKey IdFretes = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*aDZwLt92+w2UxDX4WgIsZg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Fretes")]
		public ENFretesEntityRecord ssENFretes;


		public static implicit operator ENFretesEntityRecord(RCFretesRecord r) {
			return r.ssENFretes;
		}

		public static implicit operator RCFretesRecord(ENFretesEntityRecord r) {
			RCFretesRecord res = new RCFretesRecord(null);
			res.ssENFretes = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFretes.ChangedAttributes = value;
			}
			get {
				return ssENFretes.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFretesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFretes = new ENFretesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(8, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFretes.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFretes.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFretes.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFretes.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFretesRecord r) {
			this = r;
		}


		public static bool operator == (RCFretesRecord a, RCFretesRecord b) {
			if (a.ssENFretes != b.ssENFretes) return false;
			return true;
		}

		public static bool operator != (RCFretesRecord a, RCFretesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFretesRecord)) return false;
			return (this == (RCFretesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFretes.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFretesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFretes = new ENFretesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFretes", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFretes' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFretes = (ENFretesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFretes.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFretes.InternalRecursiveSave();
		}


		public RCFretesRecord Duplicate() {
			RCFretesRecord t;
			t.ssENFretes = (ENFretesEntityRecord) this.ssENFretes.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFretes.ToXml(this, recordElem, "Fretes", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "fretes") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Fretes")) variable.Value = ssENFretes; else variable.Optimized = true;
				variable.SetFieldName("fretes");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFretes.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFretes.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFretes) {
				return ssENFretes;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFretes.FillFromOther((IRecord) other.AttributeGet(IdFretes));
		}
		public bool IsDefault() {
			RCFretesRecord defaultStruct = new RCFretesRecord(null);
			if (this.ssENFretes != defaultStruct.ssENFretes) return false;
			return true;
		}
	} // RCFretesRecord

	/// <summary>
	/// Structure <code>RCEmpresas_ContasBancariasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCEmpresas_ContasBancariasRecord: ISerializable, ITypedRecord<RCEmpresas_ContasBancariasRecord> {
		internal static readonly GlobalObjectKey IdEmpresas_ContasBancarias = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*aSzBf_LfuqpSmVR81do2jA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Empresas_ContasBancarias")]
		public ENEmpresas_ContasBancariasEntityRecord ssENEmpresas_ContasBancarias;


		public static implicit operator ENEmpresas_ContasBancariasEntityRecord(RCEmpresas_ContasBancariasRecord r) {
			return r.ssENEmpresas_ContasBancarias;
		}

		public static implicit operator RCEmpresas_ContasBancariasRecord(ENEmpresas_ContasBancariasEntityRecord r) {
			RCEmpresas_ContasBancariasRecord res = new RCEmpresas_ContasBancariasRecord(null);
			res.ssENEmpresas_ContasBancarias = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENEmpresas_ContasBancarias.ChangedAttributes = value;
			}
			get {
				return ssENEmpresas_ContasBancarias.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCEmpresas_ContasBancariasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENEmpresas_ContasBancarias = new ENEmpresas_ContasBancariasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(7, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENEmpresas_ContasBancarias.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENEmpresas_ContasBancarias.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENEmpresas_ContasBancarias.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENEmpresas_ContasBancarias.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCEmpresas_ContasBancariasRecord r) {
			this = r;
		}


		public static bool operator == (RCEmpresas_ContasBancariasRecord a, RCEmpresas_ContasBancariasRecord b) {
			if (a.ssENEmpresas_ContasBancarias != b.ssENEmpresas_ContasBancarias) return false;
			return true;
		}

		public static bool operator != (RCEmpresas_ContasBancariasRecord a, RCEmpresas_ContasBancariasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCEmpresas_ContasBancariasRecord)) return false;
			return (this == (RCEmpresas_ContasBancariasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENEmpresas_ContasBancarias.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCEmpresas_ContasBancariasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENEmpresas_ContasBancarias = new ENEmpresas_ContasBancariasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENEmpresas_ContasBancarias", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENEmpresas_ContasBancarias' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENEmpresas_ContasBancarias = (ENEmpresas_ContasBancariasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENEmpresas_ContasBancarias.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENEmpresas_ContasBancarias.InternalRecursiveSave();
		}


		public RCEmpresas_ContasBancariasRecord Duplicate() {
			RCEmpresas_ContasBancariasRecord t;
			t.ssENEmpresas_ContasBancarias = (ENEmpresas_ContasBancariasEntityRecord) this.ssENEmpresas_ContasBancarias.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENEmpresas_ContasBancarias.ToXml(this, recordElem, "Empresas_ContasBancarias", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "empresas_contasbancarias") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Empresas_ContasBancarias")) variable.Value = ssENEmpresas_ContasBancarias; else variable.Optimized = true;
				variable.SetFieldName("empresas_contasbancarias");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENEmpresas_ContasBancarias.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENEmpresas_ContasBancarias.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdEmpresas_ContasBancarias) {
				return ssENEmpresas_ContasBancarias;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENEmpresas_ContasBancarias.FillFromOther((IRecord) other.AttributeGet(IdEmpresas_ContasBancarias));
		}
		public bool IsDefault() {
			RCEmpresas_ContasBancariasRecord defaultStruct = new RCEmpresas_ContasBancariasRecord(null);
			if (this.ssENEmpresas_ContasBancarias != defaultStruct.ssENEmpresas_ContasBancarias) return false;
			return true;
		}
	} // RCEmpresas_ContasBancariasRecord

	/// <summary>
	/// Structure <code>RCGeradoresRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCGeradoresRecord: ISerializable, ITypedRecord<RCGeradoresRecord> {
		internal static readonly GlobalObjectKey IdGeradores = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*NST7+8BRALSgwSKAeF6Y7Q");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Geradores")]
		public ENGeradoresEntityRecord ssENGeradores;


		public static implicit operator ENGeradoresEntityRecord(RCGeradoresRecord r) {
			return r.ssENGeradores;
		}

		public static implicit operator RCGeradoresRecord(ENGeradoresEntityRecord r) {
			RCGeradoresRecord res = new RCGeradoresRecord(null);
			res.ssENGeradores = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENGeradores.ChangedAttributes = value;
			}
			get {
				return ssENGeradores.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCGeradoresRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENGeradores = new ENGeradoresEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(13, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENGeradores.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENGeradores.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENGeradores.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENGeradores.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCGeradoresRecord r) {
			this = r;
		}


		public static bool operator == (RCGeradoresRecord a, RCGeradoresRecord b) {
			if (a.ssENGeradores != b.ssENGeradores) return false;
			return true;
		}

		public static bool operator != (RCGeradoresRecord a, RCGeradoresRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCGeradoresRecord)) return false;
			return (this == (RCGeradoresRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENGeradores.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCGeradoresRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENGeradores = new ENGeradoresEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENGeradores", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENGeradores' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENGeradores = (ENGeradoresEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENGeradores.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENGeradores.InternalRecursiveSave();
		}


		public RCGeradoresRecord Duplicate() {
			RCGeradoresRecord t;
			t.ssENGeradores = (ENGeradoresEntityRecord) this.ssENGeradores.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENGeradores.ToXml(this, recordElem, "Geradores", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "geradores") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Geradores")) variable.Value = ssENGeradores; else variable.Optimized = true;
				variable.SetFieldName("geradores");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENGeradores.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENGeradores.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdGeradores) {
				return ssENGeradores;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENGeradores.FillFromOther((IRecord) other.AttributeGet(IdGeradores));
		}
		public bool IsDefault() {
			RCGeradoresRecord defaultStruct = new RCGeradoresRecord(null);
			if (this.ssENGeradores != defaultStruct.ssENGeradores) return false;
			return true;
		}
	} // RCGeradoresRecord

	/// <summary>
	/// Structure <code>RCUsuariosPermissoesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCUsuariosPermissoesRecord: ISerializable, ITypedRecord<RCUsuariosPermissoesRecord> {
		internal static readonly GlobalObjectKey IdUsuariosPermissoes = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*BJwip62QpCQKXzOVYmOjRw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("UsuariosPermissoes")]
		public ENUsuariosPermissoesEntityRecord ssENUsuariosPermissoes;


		public static implicit operator ENUsuariosPermissoesEntityRecord(RCUsuariosPermissoesRecord r) {
			return r.ssENUsuariosPermissoes;
		}

		public static implicit operator RCUsuariosPermissoesRecord(ENUsuariosPermissoesEntityRecord r) {
			RCUsuariosPermissoesRecord res = new RCUsuariosPermissoesRecord(null);
			res.ssENUsuariosPermissoes = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENUsuariosPermissoes.ChangedAttributes = value;
			}
			get {
				return ssENUsuariosPermissoes.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCUsuariosPermissoesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENUsuariosPermissoes = new ENUsuariosPermissoesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(4, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENUsuariosPermissoes.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENUsuariosPermissoes.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENUsuariosPermissoes.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENUsuariosPermissoes.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCUsuariosPermissoesRecord r) {
			this = r;
		}


		public static bool operator == (RCUsuariosPermissoesRecord a, RCUsuariosPermissoesRecord b) {
			if (a.ssENUsuariosPermissoes != b.ssENUsuariosPermissoes) return false;
			return true;
		}

		public static bool operator != (RCUsuariosPermissoesRecord a, RCUsuariosPermissoesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCUsuariosPermissoesRecord)) return false;
			return (this == (RCUsuariosPermissoesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENUsuariosPermissoes.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCUsuariosPermissoesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENUsuariosPermissoes = new ENUsuariosPermissoesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENUsuariosPermissoes", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENUsuariosPermissoes' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENUsuariosPermissoes = (ENUsuariosPermissoesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENUsuariosPermissoes.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENUsuariosPermissoes.InternalRecursiveSave();
		}


		public RCUsuariosPermissoesRecord Duplicate() {
			RCUsuariosPermissoesRecord t;
			t.ssENUsuariosPermissoes = (ENUsuariosPermissoesEntityRecord) this.ssENUsuariosPermissoes.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENUsuariosPermissoes.ToXml(this, recordElem, "UsuariosPermissoes", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "usuariospermissoes") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UsuariosPermissoes")) variable.Value = ssENUsuariosPermissoes; else variable.Optimized = true;
				variable.SetFieldName("usuariospermissoes");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENUsuariosPermissoes.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENUsuariosPermissoes.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdUsuariosPermissoes) {
				return ssENUsuariosPermissoes;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENUsuariosPermissoes.FillFromOther((IRecord) other.AttributeGet(IdUsuariosPermissoes));
		}
		public bool IsDefault() {
			RCUsuariosPermissoesRecord defaultStruct = new RCUsuariosPermissoesRecord(null);
			if (this.ssENUsuariosPermissoes != defaultStruct.ssENUsuariosPermissoes) return false;
			return true;
		}
	} // RCUsuariosPermissoesRecord

	/// <summary>
	/// Structure <code>RCEmpilhadeirasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCEmpilhadeirasRecord: ISerializable, ITypedRecord<RCEmpilhadeirasRecord> {
		internal static readonly GlobalObjectKey IdEmpilhadeiras = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*MNrA+G_uiV+V_p09yv53xA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Empilhadeiras")]
		public ENEmpilhadeirasEntityRecord ssENEmpilhadeiras;


		public static implicit operator ENEmpilhadeirasEntityRecord(RCEmpilhadeirasRecord r) {
			return r.ssENEmpilhadeiras;
		}

		public static implicit operator RCEmpilhadeirasRecord(ENEmpilhadeirasEntityRecord r) {
			RCEmpilhadeirasRecord res = new RCEmpilhadeirasRecord(null);
			res.ssENEmpilhadeiras = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENEmpilhadeiras.ChangedAttributes = value;
			}
			get {
				return ssENEmpilhadeiras.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCEmpilhadeirasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENEmpilhadeiras = new ENEmpilhadeirasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(15, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENEmpilhadeiras.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENEmpilhadeiras.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENEmpilhadeiras.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENEmpilhadeiras.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCEmpilhadeirasRecord r) {
			this = r;
		}


		public static bool operator == (RCEmpilhadeirasRecord a, RCEmpilhadeirasRecord b) {
			if (a.ssENEmpilhadeiras != b.ssENEmpilhadeiras) return false;
			return true;
		}

		public static bool operator != (RCEmpilhadeirasRecord a, RCEmpilhadeirasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCEmpilhadeirasRecord)) return false;
			return (this == (RCEmpilhadeirasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENEmpilhadeiras.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCEmpilhadeirasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENEmpilhadeiras = new ENEmpilhadeirasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENEmpilhadeiras", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENEmpilhadeiras' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENEmpilhadeiras = (ENEmpilhadeirasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENEmpilhadeiras.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENEmpilhadeiras.InternalRecursiveSave();
		}


		public RCEmpilhadeirasRecord Duplicate() {
			RCEmpilhadeirasRecord t;
			t.ssENEmpilhadeiras = (ENEmpilhadeirasEntityRecord) this.ssENEmpilhadeiras.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENEmpilhadeiras.ToXml(this, recordElem, "Empilhadeiras", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "empilhadeiras") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Empilhadeiras")) variable.Value = ssENEmpilhadeiras; else variable.Optimized = true;
				variable.SetFieldName("empilhadeiras");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENEmpilhadeiras.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENEmpilhadeiras.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdEmpilhadeiras) {
				return ssENEmpilhadeiras;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENEmpilhadeiras.FillFromOther((IRecord) other.AttributeGet(IdEmpilhadeiras));
		}
		public bool IsDefault() {
			RCEmpilhadeirasRecord defaultStruct = new RCEmpilhadeirasRecord(null);
			if (this.ssENEmpilhadeiras != defaultStruct.ssENEmpilhadeiras) return false;
			return true;
		}
	} // RCEmpilhadeirasRecord

	/// <summary>
	/// Structure <code>RCFornecedores_ContasBancariasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFornecedores_ContasBancariasRecord: ISerializable, ITypedRecord<RCFornecedores_ContasBancariasRecord> {
		internal static readonly GlobalObjectKey IdFornecedores_ContasBancarias = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*N3lej8cXVSR72CLqyxk6CQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Fornecedores_ContasBancarias")]
		public ENFornecedores_ContasBancariasEntityRecord ssENFornecedores_ContasBancarias;


		public static implicit operator ENFornecedores_ContasBancariasEntityRecord(RCFornecedores_ContasBancariasRecord r) {
			return r.ssENFornecedores_ContasBancarias;
		}

		public static implicit operator RCFornecedores_ContasBancariasRecord(ENFornecedores_ContasBancariasEntityRecord r) {
			RCFornecedores_ContasBancariasRecord res = new RCFornecedores_ContasBancariasRecord(null);
			res.ssENFornecedores_ContasBancarias = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFornecedores_ContasBancarias.ChangedAttributes = value;
			}
			get {
				return ssENFornecedores_ContasBancarias.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFornecedores_ContasBancariasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFornecedores_ContasBancarias = new ENFornecedores_ContasBancariasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(7, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFornecedores_ContasBancarias.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFornecedores_ContasBancarias.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFornecedores_ContasBancarias.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFornecedores_ContasBancarias.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFornecedores_ContasBancariasRecord r) {
			this = r;
		}


		public static bool operator == (RCFornecedores_ContasBancariasRecord a, RCFornecedores_ContasBancariasRecord b) {
			if (a.ssENFornecedores_ContasBancarias != b.ssENFornecedores_ContasBancarias) return false;
			return true;
		}

		public static bool operator != (RCFornecedores_ContasBancariasRecord a, RCFornecedores_ContasBancariasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFornecedores_ContasBancariasRecord)) return false;
			return (this == (RCFornecedores_ContasBancariasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFornecedores_ContasBancarias.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFornecedores_ContasBancariasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFornecedores_ContasBancarias = new ENFornecedores_ContasBancariasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFornecedores_ContasBancarias", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFornecedores_ContasBancarias' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFornecedores_ContasBancarias = (ENFornecedores_ContasBancariasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFornecedores_ContasBancarias.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFornecedores_ContasBancarias.InternalRecursiveSave();
		}


		public RCFornecedores_ContasBancariasRecord Duplicate() {
			RCFornecedores_ContasBancariasRecord t;
			t.ssENFornecedores_ContasBancarias = (ENFornecedores_ContasBancariasEntityRecord) this.ssENFornecedores_ContasBancarias.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFornecedores_ContasBancarias.ToXml(this, recordElem, "Fornecedores_ContasBancarias", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "fornecedores_contasbancarias") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Fornecedores_ContasBancarias")) variable.Value = ssENFornecedores_ContasBancarias; else variable.Optimized = true;
				variable.SetFieldName("fornecedores_contasbancarias");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFornecedores_ContasBancarias.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFornecedores_ContasBancarias.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFornecedores_ContasBancarias) {
				return ssENFornecedores_ContasBancarias;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFornecedores_ContasBancarias.FillFromOther((IRecord) other.AttributeGet(IdFornecedores_ContasBancarias));
		}
		public bool IsDefault() {
			RCFornecedores_ContasBancariasRecord defaultStruct = new RCFornecedores_ContasBancariasRecord(null);
			if (this.ssENFornecedores_ContasBancarias != defaultStruct.ssENFornecedores_ContasBancarias) return false;
			return true;
		}
	} // RCFornecedores_ContasBancariasRecord

	/// <summary>
	/// Structure <code>RCNotasFiscaisRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCNotasFiscaisRecord: ISerializable, ITypedRecord<RCNotasFiscaisRecord> {
		internal static readonly GlobalObjectKey IdNotasFiscais = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*t7cA2unjZxtetFCJhzpsxA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("NotasFiscais")]
		public ENNotasFiscaisEntityRecord ssENNotasFiscais;


		public static implicit operator ENNotasFiscaisEntityRecord(RCNotasFiscaisRecord r) {
			return r.ssENNotasFiscais;
		}

		public static implicit operator RCNotasFiscaisRecord(ENNotasFiscaisEntityRecord r) {
			RCNotasFiscaisRecord res = new RCNotasFiscaisRecord(null);
			res.ssENNotasFiscais = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENNotasFiscais.ChangedAttributes = value;
			}
			get {
				return ssENNotasFiscais.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCNotasFiscaisRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENNotasFiscais = new ENNotasFiscaisEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(41, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENNotasFiscais.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENNotasFiscais.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENNotasFiscais.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENNotasFiscais.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCNotasFiscaisRecord r) {
			this = r;
		}


		public static bool operator == (RCNotasFiscaisRecord a, RCNotasFiscaisRecord b) {
			if (a.ssENNotasFiscais != b.ssENNotasFiscais) return false;
			return true;
		}

		public static bool operator != (RCNotasFiscaisRecord a, RCNotasFiscaisRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCNotasFiscaisRecord)) return false;
			return (this == (RCNotasFiscaisRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENNotasFiscais.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCNotasFiscaisRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENNotasFiscais = new ENNotasFiscaisEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENNotasFiscais", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENNotasFiscais' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENNotasFiscais = (ENNotasFiscaisEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENNotasFiscais.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENNotasFiscais.InternalRecursiveSave();
		}


		public RCNotasFiscaisRecord Duplicate() {
			RCNotasFiscaisRecord t;
			t.ssENNotasFiscais = (ENNotasFiscaisEntityRecord) this.ssENNotasFiscais.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENNotasFiscais.ToXml(this, recordElem, "NotasFiscais", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "notasfiscais") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".NotasFiscais")) variable.Value = ssENNotasFiscais; else variable.Optimized = true;
				variable.SetFieldName("notasfiscais");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENNotasFiscais.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENNotasFiscais.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdNotasFiscais) {
				return ssENNotasFiscais;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENNotasFiscais.FillFromOther((IRecord) other.AttributeGet(IdNotasFiscais));
		}
		public bool IsDefault() {
			RCNotasFiscaisRecord defaultStruct = new RCNotasFiscaisRecord(null);
			if (this.ssENNotasFiscais != defaultStruct.ssENNotasFiscais) return false;
			return true;
		}
	} // RCNotasFiscaisRecord

	/// <summary>
	/// Structure <code>RCEmpilhadeiras_ManutencoesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCEmpilhadeiras_ManutencoesRecord: ISerializable, ITypedRecord<RCEmpilhadeiras_ManutencoesRecord> {
		internal static readonly GlobalObjectKey IdEmpilhadeiras_Manutencoes = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*3472laP0gHcYqr4TBAuoeQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Empilhadeiras_Manutencoes")]
		public ENEmpilhadeiras_ManutencoesEntityRecord ssENEmpilhadeiras_Manutencoes;


		public static implicit operator ENEmpilhadeiras_ManutencoesEntityRecord(RCEmpilhadeiras_ManutencoesRecord r) {
			return r.ssENEmpilhadeiras_Manutencoes;
		}

		public static implicit operator RCEmpilhadeiras_ManutencoesRecord(ENEmpilhadeiras_ManutencoesEntityRecord r) {
			RCEmpilhadeiras_ManutencoesRecord res = new RCEmpilhadeiras_ManutencoesRecord(null);
			res.ssENEmpilhadeiras_Manutencoes = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENEmpilhadeiras_Manutencoes.ChangedAttributes = value;
			}
			get {
				return ssENEmpilhadeiras_Manutencoes.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCEmpilhadeiras_ManutencoesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENEmpilhadeiras_Manutencoes = new ENEmpilhadeiras_ManutencoesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(5, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENEmpilhadeiras_Manutencoes.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENEmpilhadeiras_Manutencoes.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENEmpilhadeiras_Manutencoes.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENEmpilhadeiras_Manutencoes.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCEmpilhadeiras_ManutencoesRecord r) {
			this = r;
		}


		public static bool operator == (RCEmpilhadeiras_ManutencoesRecord a, RCEmpilhadeiras_ManutencoesRecord b) {
			if (a.ssENEmpilhadeiras_Manutencoes != b.ssENEmpilhadeiras_Manutencoes) return false;
			return true;
		}

		public static bool operator != (RCEmpilhadeiras_ManutencoesRecord a, RCEmpilhadeiras_ManutencoesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCEmpilhadeiras_ManutencoesRecord)) return false;
			return (this == (RCEmpilhadeiras_ManutencoesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENEmpilhadeiras_Manutencoes.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCEmpilhadeiras_ManutencoesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENEmpilhadeiras_Manutencoes = new ENEmpilhadeiras_ManutencoesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENEmpilhadeiras_Manutencoes", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENEmpilhadeiras_Manutencoes' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENEmpilhadeiras_Manutencoes = (ENEmpilhadeiras_ManutencoesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENEmpilhadeiras_Manutencoes.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENEmpilhadeiras_Manutencoes.InternalRecursiveSave();
		}


		public RCEmpilhadeiras_ManutencoesRecord Duplicate() {
			RCEmpilhadeiras_ManutencoesRecord t;
			t.ssENEmpilhadeiras_Manutencoes = (ENEmpilhadeiras_ManutencoesEntityRecord) this.ssENEmpilhadeiras_Manutencoes.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENEmpilhadeiras_Manutencoes.ToXml(this, recordElem, "Empilhadeiras_Manutencoes", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "empilhadeiras_manutencoes") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Empilhadeiras_Manutencoes")) variable.Value = ssENEmpilhadeiras_Manutencoes; else variable.Optimized = true;
				variable.SetFieldName("empilhadeiras_manutencoes");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENEmpilhadeiras_Manutencoes.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENEmpilhadeiras_Manutencoes.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdEmpilhadeiras_Manutencoes) {
				return ssENEmpilhadeiras_Manutencoes;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENEmpilhadeiras_Manutencoes.FillFromOther((IRecord) other.AttributeGet(IdEmpilhadeiras_Manutencoes));
		}
		public bool IsDefault() {
			RCEmpilhadeiras_ManutencoesRecord defaultStruct = new RCEmpilhadeiras_ManutencoesRecord(null);
			if (this.ssENEmpilhadeiras_Manutencoes != defaultStruct.ssENEmpilhadeiras_Manutencoes) return false;
			return true;
		}
	} // RCEmpilhadeiras_ManutencoesRecord

	/// <summary>
	/// Structure <code>RCUEN_CentrosCustosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCUEN_CentrosCustosRecord: ISerializable, ITypedRecord<RCUEN_CentrosCustosRecord> {
		internal static readonly GlobalObjectKey IdUEN_CentrosCustos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*cckMDuywnM3T4UGP_accqQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("UEN_CentrosCustos")]
		public ENUEN_CentrosCustosEntityRecord ssENUEN_CentrosCustos;


		public static implicit operator ENUEN_CentrosCustosEntityRecord(RCUEN_CentrosCustosRecord r) {
			return r.ssENUEN_CentrosCustos;
		}

		public static implicit operator RCUEN_CentrosCustosRecord(ENUEN_CentrosCustosEntityRecord r) {
			RCUEN_CentrosCustosRecord res = new RCUEN_CentrosCustosRecord(null);
			res.ssENUEN_CentrosCustos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENUEN_CentrosCustos.ChangedAttributes = value;
			}
			get {
				return ssENUEN_CentrosCustos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCUEN_CentrosCustosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENUEN_CentrosCustos = new ENUEN_CentrosCustosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENUEN_CentrosCustos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENUEN_CentrosCustos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENUEN_CentrosCustos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENUEN_CentrosCustos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCUEN_CentrosCustosRecord r) {
			this = r;
		}


		public static bool operator == (RCUEN_CentrosCustosRecord a, RCUEN_CentrosCustosRecord b) {
			if (a.ssENUEN_CentrosCustos != b.ssENUEN_CentrosCustos) return false;
			return true;
		}

		public static bool operator != (RCUEN_CentrosCustosRecord a, RCUEN_CentrosCustosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCUEN_CentrosCustosRecord)) return false;
			return (this == (RCUEN_CentrosCustosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENUEN_CentrosCustos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCUEN_CentrosCustosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENUEN_CentrosCustos = new ENUEN_CentrosCustosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENUEN_CentrosCustos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENUEN_CentrosCustos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENUEN_CentrosCustos = (ENUEN_CentrosCustosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENUEN_CentrosCustos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENUEN_CentrosCustos.InternalRecursiveSave();
		}


		public RCUEN_CentrosCustosRecord Duplicate() {
			RCUEN_CentrosCustosRecord t;
			t.ssENUEN_CentrosCustos = (ENUEN_CentrosCustosEntityRecord) this.ssENUEN_CentrosCustos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENUEN_CentrosCustos.ToXml(this, recordElem, "UEN_CentrosCustos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "uen_centroscustos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UEN_CentrosCustos")) variable.Value = ssENUEN_CentrosCustos; else variable.Optimized = true;
				variable.SetFieldName("uen_centroscustos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENUEN_CentrosCustos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENUEN_CentrosCustos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdUEN_CentrosCustos) {
				return ssENUEN_CentrosCustos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENUEN_CentrosCustos.FillFromOther((IRecord) other.AttributeGet(IdUEN_CentrosCustos));
		}
		public bool IsDefault() {
			RCUEN_CentrosCustosRecord defaultStruct = new RCUEN_CentrosCustosRecord(null);
			if (this.ssENUEN_CentrosCustos != defaultStruct.ssENUEN_CentrosCustos) return false;
			return true;
		}
	} // RCUEN_CentrosCustosRecord

	/// <summary>
	/// Structure <code>RCFeriadosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFeriadosRecord: ISerializable, ITypedRecord<RCFeriadosRecord> {
		internal static readonly GlobalObjectKey IdFeriados = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*fYen53J0oiwyMont6gT6Ig");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Feriados")]
		public ENFeriadosEntityRecord ssENFeriados;


		public static implicit operator ENFeriadosEntityRecord(RCFeriadosRecord r) {
			return r.ssENFeriados;
		}

		public static implicit operator RCFeriadosRecord(ENFeriadosEntityRecord r) {
			RCFeriadosRecord res = new RCFeriadosRecord(null);
			res.ssENFeriados = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFeriados.ChangedAttributes = value;
			}
			get {
				return ssENFeriados.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFeriadosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFeriados = new ENFeriadosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(5, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFeriados.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFeriados.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFeriados.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFeriados.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFeriadosRecord r) {
			this = r;
		}


		public static bool operator == (RCFeriadosRecord a, RCFeriadosRecord b) {
			if (a.ssENFeriados != b.ssENFeriados) return false;
			return true;
		}

		public static bool operator != (RCFeriadosRecord a, RCFeriadosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFeriadosRecord)) return false;
			return (this == (RCFeriadosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFeriados.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFeriadosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFeriados = new ENFeriadosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFeriados", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFeriados' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFeriados = (ENFeriadosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFeriados.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFeriados.InternalRecursiveSave();
		}


		public RCFeriadosRecord Duplicate() {
			RCFeriadosRecord t;
			t.ssENFeriados = (ENFeriadosEntityRecord) this.ssENFeriados.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFeriados.ToXml(this, recordElem, "Feriados", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "feriados") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Feriados")) variable.Value = ssENFeriados; else variable.Optimized = true;
				variable.SetFieldName("feriados");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFeriados.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFeriados.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFeriados) {
				return ssENFeriados;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFeriados.FillFromOther((IRecord) other.AttributeGet(IdFeriados));
		}
		public bool IsDefault() {
			RCFeriadosRecord defaultStruct = new RCFeriadosRecord(null);
			if (this.ssENFeriados != defaultStruct.ssENFeriados) return false;
			return true;
		}
	} // RCFeriadosRecord

	/// <summary>
	/// Structure <code>RCObrasEtapasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCObrasEtapasRecord: ISerializable, ITypedRecord<RCObrasEtapasRecord> {
		internal static readonly GlobalObjectKey IdObrasEtapas = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*1nW2v_1uI_wTtkpMdb3JfA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ObrasEtapas")]
		public ENObrasEtapasEntityRecord ssENObrasEtapas;


		public static implicit operator ENObrasEtapasEntityRecord(RCObrasEtapasRecord r) {
			return r.ssENObrasEtapas;
		}

		public static implicit operator RCObrasEtapasRecord(ENObrasEtapasEntityRecord r) {
			RCObrasEtapasRecord res = new RCObrasEtapasRecord(null);
			res.ssENObrasEtapas = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENObrasEtapas.ChangedAttributes = value;
			}
			get {
				return ssENObrasEtapas.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCObrasEtapasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENObrasEtapas = new ENObrasEtapasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(12, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENObrasEtapas.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENObrasEtapas.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENObrasEtapas.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENObrasEtapas.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCObrasEtapasRecord r) {
			this = r;
		}


		public static bool operator == (RCObrasEtapasRecord a, RCObrasEtapasRecord b) {
			if (a.ssENObrasEtapas != b.ssENObrasEtapas) return false;
			return true;
		}

		public static bool operator != (RCObrasEtapasRecord a, RCObrasEtapasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCObrasEtapasRecord)) return false;
			return (this == (RCObrasEtapasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENObrasEtapas.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCObrasEtapasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENObrasEtapas = new ENObrasEtapasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENObrasEtapas", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENObrasEtapas' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENObrasEtapas = (ENObrasEtapasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENObrasEtapas.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENObrasEtapas.InternalRecursiveSave();
		}


		public RCObrasEtapasRecord Duplicate() {
			RCObrasEtapasRecord t;
			t.ssENObrasEtapas = (ENObrasEtapasEntityRecord) this.ssENObrasEtapas.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENObrasEtapas.ToXml(this, recordElem, "ObrasEtapas", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "obrasetapas") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ObrasEtapas")) variable.Value = ssENObrasEtapas; else variable.Optimized = true;
				variable.SetFieldName("obrasetapas");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdObrasEtapas) {
				return ssENObrasEtapas;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENObrasEtapas.FillFromOther((IRecord) other.AttributeGet(IdObrasEtapas));
		}
		public bool IsDefault() {
			RCObrasEtapasRecord defaultStruct = new RCObrasEtapasRecord(null);
			if (this.ssENObrasEtapas != defaultStruct.ssENObrasEtapas) return false;
			return true;
		}
	} // RCObrasEtapasRecord

	/// <summary>
	/// Structure <code>RCFuncionariosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFuncionariosRecord: ISerializable, ITypedRecord<RCFuncionariosRecord> {
		internal static readonly GlobalObjectKey IdFuncionarios = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*kmv2c2yDzrVwT4K0xEXCVQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Funcionarios")]
		public ENFuncionariosEntityRecord ssENFuncionarios;


		public static implicit operator ENFuncionariosEntityRecord(RCFuncionariosRecord r) {
			return r.ssENFuncionarios;
		}

		public static implicit operator RCFuncionariosRecord(ENFuncionariosEntityRecord r) {
			RCFuncionariosRecord res = new RCFuncionariosRecord(null);
			res.ssENFuncionarios = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFuncionarios.ChangedAttributes = value;
			}
			get {
				return ssENFuncionarios.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFuncionariosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFuncionarios = new ENFuncionariosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(2, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFuncionarios.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFuncionarios.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFuncionarios.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFuncionarios.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFuncionariosRecord r) {
			this = r;
		}


		public static bool operator == (RCFuncionariosRecord a, RCFuncionariosRecord b) {
			if (a.ssENFuncionarios != b.ssENFuncionarios) return false;
			return true;
		}

		public static bool operator != (RCFuncionariosRecord a, RCFuncionariosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFuncionariosRecord)) return false;
			return (this == (RCFuncionariosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFuncionarios.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFuncionariosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFuncionarios = new ENFuncionariosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFuncionarios", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFuncionarios' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFuncionarios = (ENFuncionariosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFuncionarios.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFuncionarios.InternalRecursiveSave();
		}


		public RCFuncionariosRecord Duplicate() {
			RCFuncionariosRecord t;
			t.ssENFuncionarios = (ENFuncionariosEntityRecord) this.ssENFuncionarios.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFuncionarios.ToXml(this, recordElem, "Funcionarios", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "funcionarios") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Funcionarios")) variable.Value = ssENFuncionarios; else variable.Optimized = true;
				variable.SetFieldName("funcionarios");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFuncionarios.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFuncionarios.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFuncionarios) {
				return ssENFuncionarios;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFuncionarios.FillFromOther((IRecord) other.AttributeGet(IdFuncionarios));
		}
		public bool IsDefault() {
			RCFuncionariosRecord defaultStruct = new RCFuncionariosRecord(null);
			if (this.ssENFuncionarios != defaultStruct.ssENFuncionarios) return false;
			return true;
		}
	} // RCFuncionariosRecord

	/// <summary>
	/// Structure <code>RCMultas_GravidadeRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCMultas_GravidadeRecord: ISerializable, ITypedRecord<RCMultas_GravidadeRecord> {
		internal static readonly GlobalObjectKey IdMultas_Gravidade = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*tViUGF+9PeuUexluKC6O0Q");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Multas_Gravidade")]
		public ENMultas_GravidadeEntityRecord ssENMultas_Gravidade;


		public static implicit operator ENMultas_GravidadeEntityRecord(RCMultas_GravidadeRecord r) {
			return r.ssENMultas_Gravidade;
		}

		public static implicit operator RCMultas_GravidadeRecord(ENMultas_GravidadeEntityRecord r) {
			RCMultas_GravidadeRecord res = new RCMultas_GravidadeRecord(null);
			res.ssENMultas_Gravidade = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENMultas_Gravidade.ChangedAttributes = value;
			}
			get {
				return ssENMultas_Gravidade.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCMultas_GravidadeRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENMultas_Gravidade = new ENMultas_GravidadeEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(4, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENMultas_Gravidade.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENMultas_Gravidade.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENMultas_Gravidade.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENMultas_Gravidade.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCMultas_GravidadeRecord r) {
			this = r;
		}


		public static bool operator == (RCMultas_GravidadeRecord a, RCMultas_GravidadeRecord b) {
			if (a.ssENMultas_Gravidade != b.ssENMultas_Gravidade) return false;
			return true;
		}

		public static bool operator != (RCMultas_GravidadeRecord a, RCMultas_GravidadeRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCMultas_GravidadeRecord)) return false;
			return (this == (RCMultas_GravidadeRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENMultas_Gravidade.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCMultas_GravidadeRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENMultas_Gravidade = new ENMultas_GravidadeEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENMultas_Gravidade", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENMultas_Gravidade' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENMultas_Gravidade = (ENMultas_GravidadeEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENMultas_Gravidade.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENMultas_Gravidade.InternalRecursiveSave();
		}


		public RCMultas_GravidadeRecord Duplicate() {
			RCMultas_GravidadeRecord t;
			t.ssENMultas_Gravidade = (ENMultas_GravidadeEntityRecord) this.ssENMultas_Gravidade.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENMultas_Gravidade.ToXml(this, recordElem, "Multas_Gravidade", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "multas_gravidade") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Multas_Gravidade")) variable.Value = ssENMultas_Gravidade; else variable.Optimized = true;
				variable.SetFieldName("multas_gravidade");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENMultas_Gravidade.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENMultas_Gravidade.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdMultas_Gravidade) {
				return ssENMultas_Gravidade;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENMultas_Gravidade.FillFromOther((IRecord) other.AttributeGet(IdMultas_Gravidade));
		}
		public bool IsDefault() {
			RCMultas_GravidadeRecord defaultStruct = new RCMultas_GravidadeRecord(null);
			if (this.ssENMultas_Gravidade != defaultStruct.ssENMultas_Gravidade) return false;
			return true;
		}
	} // RCMultas_GravidadeRecord

	/// <summary>
	/// Structure <code>RCManutencoesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCManutencoesRecord: ISerializable, ITypedRecord<RCManutencoesRecord> {
		internal static readonly GlobalObjectKey IdManutencoes = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*VbFibp8frb3+7a4rXgeycA");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Manutencoes")]
		public ENManutencoesEntityRecord ssENManutencoes;


		public static implicit operator ENManutencoesEntityRecord(RCManutencoesRecord r) {
			return r.ssENManutencoes;
		}

		public static implicit operator RCManutencoesRecord(ENManutencoesEntityRecord r) {
			RCManutencoesRecord res = new RCManutencoesRecord(null);
			res.ssENManutencoes = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENManutencoes.ChangedAttributes = value;
			}
			get {
				return ssENManutencoes.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCManutencoesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENManutencoes = new ENManutencoesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(9, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENManutencoes.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENManutencoes.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENManutencoes.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENManutencoes.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCManutencoesRecord r) {
			this = r;
		}


		public static bool operator == (RCManutencoesRecord a, RCManutencoesRecord b) {
			if (a.ssENManutencoes != b.ssENManutencoes) return false;
			return true;
		}

		public static bool operator != (RCManutencoesRecord a, RCManutencoesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCManutencoesRecord)) return false;
			return (this == (RCManutencoesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENManutencoes.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCManutencoesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENManutencoes = new ENManutencoesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENManutencoes", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENManutencoes' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENManutencoes = (ENManutencoesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENManutencoes.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENManutencoes.InternalRecursiveSave();
		}


		public RCManutencoesRecord Duplicate() {
			RCManutencoesRecord t;
			t.ssENManutencoes = (ENManutencoesEntityRecord) this.ssENManutencoes.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENManutencoes.ToXml(this, recordElem, "Manutencoes", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "manutencoes") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Manutencoes")) variable.Value = ssENManutencoes; else variable.Optimized = true;
				variable.SetFieldName("manutencoes");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENManutencoes.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENManutencoes.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdManutencoes) {
				return ssENManutencoes;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENManutencoes.FillFromOther((IRecord) other.AttributeGet(IdManutencoes));
		}
		public bool IsDefault() {
			RCManutencoesRecord defaultStruct = new RCManutencoesRecord(null);
			if (this.ssENManutencoes != defaultStruct.ssENManutencoes) return false;
			return true;
		}
	} // RCManutencoesRecord

	/// <summary>
	/// Structure <code>RCUsuariosCentroCustoRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCUsuariosCentroCustoRecord: ISerializable, ITypedRecord<RCUsuariosCentroCustoRecord> {
		internal static readonly GlobalObjectKey IdUsuariosCentroCusto = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*hGLIb9MixXFK8qIrlAvK8g");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("UsuariosCentroCusto")]
		public ENUsuariosCentroCustoEntityRecord ssENUsuariosCentroCusto;


		public static implicit operator ENUsuariosCentroCustoEntityRecord(RCUsuariosCentroCustoRecord r) {
			return r.ssENUsuariosCentroCusto;
		}

		public static implicit operator RCUsuariosCentroCustoRecord(ENUsuariosCentroCustoEntityRecord r) {
			RCUsuariosCentroCustoRecord res = new RCUsuariosCentroCustoRecord(null);
			res.ssENUsuariosCentroCusto = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENUsuariosCentroCusto.ChangedAttributes = value;
			}
			get {
				return ssENUsuariosCentroCusto.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCUsuariosCentroCustoRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENUsuariosCentroCusto = new ENUsuariosCentroCustoEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(3, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENUsuariosCentroCusto.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENUsuariosCentroCusto.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENUsuariosCentroCusto.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENUsuariosCentroCusto.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCUsuariosCentroCustoRecord r) {
			this = r;
		}


		public static bool operator == (RCUsuariosCentroCustoRecord a, RCUsuariosCentroCustoRecord b) {
			if (a.ssENUsuariosCentroCusto != b.ssENUsuariosCentroCusto) return false;
			return true;
		}

		public static bool operator != (RCUsuariosCentroCustoRecord a, RCUsuariosCentroCustoRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCUsuariosCentroCustoRecord)) return false;
			return (this == (RCUsuariosCentroCustoRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENUsuariosCentroCusto.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCUsuariosCentroCustoRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENUsuariosCentroCusto = new ENUsuariosCentroCustoEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENUsuariosCentroCusto", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENUsuariosCentroCusto' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENUsuariosCentroCusto = (ENUsuariosCentroCustoEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENUsuariosCentroCusto.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENUsuariosCentroCusto.InternalRecursiveSave();
		}


		public RCUsuariosCentroCustoRecord Duplicate() {
			RCUsuariosCentroCustoRecord t;
			t.ssENUsuariosCentroCusto = (ENUsuariosCentroCustoEntityRecord) this.ssENUsuariosCentroCusto.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENUsuariosCentroCusto.ToXml(this, recordElem, "UsuariosCentroCusto", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "usuarioscentrocusto") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UsuariosCentroCusto")) variable.Value = ssENUsuariosCentroCusto; else variable.Optimized = true;
				variable.SetFieldName("usuarioscentrocusto");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENUsuariosCentroCusto.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENUsuariosCentroCusto.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdUsuariosCentroCusto) {
				return ssENUsuariosCentroCusto;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENUsuariosCentroCusto.FillFromOther((IRecord) other.AttributeGet(IdUsuariosCentroCusto));
		}
		public bool IsDefault() {
			RCUsuariosCentroCustoRecord defaultStruct = new RCUsuariosCentroCustoRecord(null);
			if (this.ssENUsuariosCentroCusto != defaultStruct.ssENUsuariosCentroCusto) return false;
			return true;
		}
	} // RCUsuariosCentroCustoRecord

	/// <summary>
	/// Structure <code>RCObrasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCObrasRecord: ISerializable, ITypedRecord<RCObrasRecord> {
		internal static readonly GlobalObjectKey IdObras = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*SgVXnWG8uXQD+NEmfRUnow");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Obras")]
		public ENObrasEntityRecord ssENObras;


		public static implicit operator ENObrasEntityRecord(RCObrasRecord r) {
			return r.ssENObras;
		}

		public static implicit operator RCObrasRecord(ENObrasEntityRecord r) {
			RCObrasRecord res = new RCObrasRecord(null);
			res.ssENObras = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENObras.ChangedAttributes = value;
			}
			get {
				return ssENObras.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCObrasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENObras = new ENObrasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(7, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENObras.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENObras.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENObras.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENObras.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCObrasRecord r) {
			this = r;
		}


		public static bool operator == (RCObrasRecord a, RCObrasRecord b) {
			if (a.ssENObras != b.ssENObras) return false;
			return true;
		}

		public static bool operator != (RCObrasRecord a, RCObrasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCObrasRecord)) return false;
			return (this == (RCObrasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENObras.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCObrasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENObras = new ENObrasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENObras", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENObras' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENObras = (ENObrasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENObras.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENObras.InternalRecursiveSave();
		}


		public RCObrasRecord Duplicate() {
			RCObrasRecord t;
			t.ssENObras = (ENObrasEntityRecord) this.ssENObras.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENObras.ToXml(this, recordElem, "Obras", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "obras") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Obras")) variable.Value = ssENObras; else variable.Optimized = true;
				variable.SetFieldName("obras");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENObras.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENObras.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdObras) {
				return ssENObras;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENObras.FillFromOther((IRecord) other.AttributeGet(IdObras));
		}
		public bool IsDefault() {
			RCObrasRecord defaultStruct = new RCObrasRecord(null);
			if (this.ssENObras != defaultStruct.ssENObras) return false;
			return true;
		}
	} // RCObrasRecord

	/// <summary>
	/// Structure <code>RCFretes_ObrasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFretes_ObrasRecord: ISerializable, ITypedRecord<RCFretes_ObrasRecord> {
		internal static readonly GlobalObjectKey IdFretes_Obras = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*xzlquYB+iFCiZO8JMY12Iw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Fretes_Obras")]
		public ENFretes_ObrasEntityRecord ssENFretes_Obras;


		public static implicit operator ENFretes_ObrasEntityRecord(RCFretes_ObrasRecord r) {
			return r.ssENFretes_Obras;
		}

		public static implicit operator RCFretes_ObrasRecord(ENFretes_ObrasEntityRecord r) {
			RCFretes_ObrasRecord res = new RCFretes_ObrasRecord(null);
			res.ssENFretes_Obras = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFretes_Obras.ChangedAttributes = value;
			}
			get {
				return ssENFretes_Obras.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFretes_ObrasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFretes_Obras = new ENFretes_ObrasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(9, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFretes_Obras.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFretes_Obras.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFretes_Obras.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFretes_Obras.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFretes_ObrasRecord r) {
			this = r;
		}


		public static bool operator == (RCFretes_ObrasRecord a, RCFretes_ObrasRecord b) {
			if (a.ssENFretes_Obras != b.ssENFretes_Obras) return false;
			return true;
		}

		public static bool operator != (RCFretes_ObrasRecord a, RCFretes_ObrasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFretes_ObrasRecord)) return false;
			return (this == (RCFretes_ObrasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFretes_Obras.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFretes_ObrasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFretes_Obras = new ENFretes_ObrasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFretes_Obras", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFretes_Obras' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFretes_Obras = (ENFretes_ObrasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFretes_Obras.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFretes_Obras.InternalRecursiveSave();
		}


		public RCFretes_ObrasRecord Duplicate() {
			RCFretes_ObrasRecord t;
			t.ssENFretes_Obras = (ENFretes_ObrasEntityRecord) this.ssENFretes_Obras.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFretes_Obras.ToXml(this, recordElem, "Fretes_Obras", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "fretes_obras") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Fretes_Obras")) variable.Value = ssENFretes_Obras; else variable.Optimized = true;
				variable.SetFieldName("fretes_obras");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFretes_Obras.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFretes_Obras.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFretes_Obras) {
				return ssENFretes_Obras;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFretes_Obras.FillFromOther((IRecord) other.AttributeGet(IdFretes_Obras));
		}
		public bool IsDefault() {
			RCFretes_ObrasRecord defaultStruct = new RCFretes_ObrasRecord(null);
			if (this.ssENFretes_Obras != defaultStruct.ssENFretes_Obras) return false;
			return true;
		}
	} // RCFretes_ObrasRecord

	/// <summary>
	/// Structure <code>RCOrdemPagamentoItensRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCOrdemPagamentoItensRecord: ISerializable, ITypedRecord<RCOrdemPagamentoItensRecord> {
		internal static readonly GlobalObjectKey IdOrdemPagamentoItens = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*yoRFP6ycDmEw87EuyhBhVw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("OrdemPagamentoItens")]
		public ENOrdemPagamentoItensEntityRecord ssENOrdemPagamentoItens;


		public static implicit operator ENOrdemPagamentoItensEntityRecord(RCOrdemPagamentoItensRecord r) {
			return r.ssENOrdemPagamentoItens;
		}

		public static implicit operator RCOrdemPagamentoItensRecord(ENOrdemPagamentoItensEntityRecord r) {
			RCOrdemPagamentoItensRecord res = new RCOrdemPagamentoItensRecord(null);
			res.ssENOrdemPagamentoItens = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENOrdemPagamentoItens.ChangedAttributes = value;
			}
			get {
				return ssENOrdemPagamentoItens.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCOrdemPagamentoItensRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENOrdemPagamentoItens = new ENOrdemPagamentoItensEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(17, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENOrdemPagamentoItens.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENOrdemPagamentoItens.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENOrdemPagamentoItens.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENOrdemPagamentoItens.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCOrdemPagamentoItensRecord r) {
			this = r;
		}


		public static bool operator == (RCOrdemPagamentoItensRecord a, RCOrdemPagamentoItensRecord b) {
			if (a.ssENOrdemPagamentoItens != b.ssENOrdemPagamentoItens) return false;
			return true;
		}

		public static bool operator != (RCOrdemPagamentoItensRecord a, RCOrdemPagamentoItensRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCOrdemPagamentoItensRecord)) return false;
			return (this == (RCOrdemPagamentoItensRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENOrdemPagamentoItens.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCOrdemPagamentoItensRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENOrdemPagamentoItens = new ENOrdemPagamentoItensEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENOrdemPagamentoItens", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENOrdemPagamentoItens' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENOrdemPagamentoItens = (ENOrdemPagamentoItensEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENOrdemPagamentoItens.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENOrdemPagamentoItens.InternalRecursiveSave();
		}


		public RCOrdemPagamentoItensRecord Duplicate() {
			RCOrdemPagamentoItensRecord t;
			t.ssENOrdemPagamentoItens = (ENOrdemPagamentoItensEntityRecord) this.ssENOrdemPagamentoItens.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENOrdemPagamentoItens.ToXml(this, recordElem, "OrdemPagamentoItens", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "ordempagamentoitens") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".OrdemPagamentoItens")) variable.Value = ssENOrdemPagamentoItens; else variable.Optimized = true;
				variable.SetFieldName("ordempagamentoitens");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENOrdemPagamentoItens.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENOrdemPagamentoItens.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdOrdemPagamentoItens) {
				return ssENOrdemPagamentoItens;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENOrdemPagamentoItens.FillFromOther((IRecord) other.AttributeGet(IdOrdemPagamentoItens));
		}
		public bool IsDefault() {
			RCOrdemPagamentoItensRecord defaultStruct = new RCOrdemPagamentoItensRecord(null);
			if (this.ssENOrdemPagamentoItens != defaultStruct.ssENOrdemPagamentoItens) return false;
			return true;
		}
	} // RCOrdemPagamentoItensRecord

	/// <summary>
	/// Structure <code>RCClientes_ContasBancariasRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCClientes_ContasBancariasRecord: ISerializable, ITypedRecord<RCClientes_ContasBancariasRecord> {
		internal static readonly GlobalObjectKey IdClientes_ContasBancarias = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*yOk572grMI1QlrYy_DmQJw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Clientes_ContasBancarias")]
		public ENClientes_ContasBancariasEntityRecord ssENClientes_ContasBancarias;


		public static implicit operator ENClientes_ContasBancariasEntityRecord(RCClientes_ContasBancariasRecord r) {
			return r.ssENClientes_ContasBancarias;
		}

		public static implicit operator RCClientes_ContasBancariasRecord(ENClientes_ContasBancariasEntityRecord r) {
			RCClientes_ContasBancariasRecord res = new RCClientes_ContasBancariasRecord(null);
			res.ssENClientes_ContasBancarias = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENClientes_ContasBancarias.ChangedAttributes = value;
			}
			get {
				return ssENClientes_ContasBancarias.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCClientes_ContasBancariasRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENClientes_ContasBancarias = new ENClientes_ContasBancariasEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(7, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENClientes_ContasBancarias.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENClientes_ContasBancarias.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENClientes_ContasBancarias.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENClientes_ContasBancarias.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCClientes_ContasBancariasRecord r) {
			this = r;
		}


		public static bool operator == (RCClientes_ContasBancariasRecord a, RCClientes_ContasBancariasRecord b) {
			if (a.ssENClientes_ContasBancarias != b.ssENClientes_ContasBancarias) return false;
			return true;
		}

		public static bool operator != (RCClientes_ContasBancariasRecord a, RCClientes_ContasBancariasRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCClientes_ContasBancariasRecord)) return false;
			return (this == (RCClientes_ContasBancariasRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENClientes_ContasBancarias.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCClientes_ContasBancariasRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENClientes_ContasBancarias = new ENClientes_ContasBancariasEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENClientes_ContasBancarias", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENClientes_ContasBancarias' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENClientes_ContasBancarias = (ENClientes_ContasBancariasEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENClientes_ContasBancarias.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENClientes_ContasBancarias.InternalRecursiveSave();
		}


		public RCClientes_ContasBancariasRecord Duplicate() {
			RCClientes_ContasBancariasRecord t;
			t.ssENClientes_ContasBancarias = (ENClientes_ContasBancariasEntityRecord) this.ssENClientes_ContasBancarias.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENClientes_ContasBancarias.ToXml(this, recordElem, "Clientes_ContasBancarias", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "clientes_contasbancarias") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Clientes_ContasBancarias")) variable.Value = ssENClientes_ContasBancarias; else variable.Optimized = true;
				variable.SetFieldName("clientes_contasbancarias");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENClientes_ContasBancarias.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENClientes_ContasBancarias.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdClientes_ContasBancarias) {
				return ssENClientes_ContasBancarias;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENClientes_ContasBancarias.FillFromOther((IRecord) other.AttributeGet(IdClientes_ContasBancarias));
		}
		public bool IsDefault() {
			RCClientes_ContasBancariasRecord defaultStruct = new RCClientes_ContasBancariasRecord(null);
			if (this.ssENClientes_ContasBancarias != defaultStruct.ssENClientes_ContasBancarias) return false;
			return true;
		}
	} // RCClientes_ContasBancariasRecord

	/// <summary>
	/// Structure <code>RCCentrosCustosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCCentrosCustosRecord: ISerializable, ITypedRecord<RCCentrosCustosRecord> {
		internal static readonly GlobalObjectKey IdCentrosCustos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*J9Snty0xMo9IusOkcsTBJw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("CentrosCustos")]
		public ENCentrosCustosEntityRecord ssENCentrosCustos;


		public static implicit operator ENCentrosCustosEntityRecord(RCCentrosCustosRecord r) {
			return r.ssENCentrosCustos;
		}

		public static implicit operator RCCentrosCustosRecord(ENCentrosCustosEntityRecord r) {
			RCCentrosCustosRecord res = new RCCentrosCustosRecord(null);
			res.ssENCentrosCustos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENCentrosCustos.ChangedAttributes = value;
			}
			get {
				return ssENCentrosCustos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCCentrosCustosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENCentrosCustos = new ENCentrosCustosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(5, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENCentrosCustos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENCentrosCustos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENCentrosCustos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENCentrosCustos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCCentrosCustosRecord r) {
			this = r;
		}


		public static bool operator == (RCCentrosCustosRecord a, RCCentrosCustosRecord b) {
			if (a.ssENCentrosCustos != b.ssENCentrosCustos) return false;
			return true;
		}

		public static bool operator != (RCCentrosCustosRecord a, RCCentrosCustosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCCentrosCustosRecord)) return false;
			return (this == (RCCentrosCustosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENCentrosCustos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCCentrosCustosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENCentrosCustos = new ENCentrosCustosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENCentrosCustos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENCentrosCustos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENCentrosCustos = (ENCentrosCustosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENCentrosCustos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENCentrosCustos.InternalRecursiveSave();
		}


		public RCCentrosCustosRecord Duplicate() {
			RCCentrosCustosRecord t;
			t.ssENCentrosCustos = (ENCentrosCustosEntityRecord) this.ssENCentrosCustos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENCentrosCustos.ToXml(this, recordElem, "CentrosCustos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "centroscustos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".CentrosCustos")) variable.Value = ssENCentrosCustos; else variable.Optimized = true;
				variable.SetFieldName("centroscustos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENCentrosCustos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENCentrosCustos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdCentrosCustos) {
				return ssENCentrosCustos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENCentrosCustos.FillFromOther((IRecord) other.AttributeGet(IdCentrosCustos));
		}
		public bool IsDefault() {
			RCCentrosCustosRecord defaultStruct = new RCCentrosCustosRecord(null);
			if (this.ssENCentrosCustos != defaultStruct.ssENCentrosCustos) return false;
			return true;
		}
	} // RCCentrosCustosRecord

	/// <summary>
	/// Structure <code>RCClientes_ContatosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCClientes_ContatosRecord: ISerializable, ITypedRecord<RCClientes_ContatosRecord> {
		internal static readonly GlobalObjectKey IdClientes_Contatos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*Cv7mSMq_Nv5fP5ACYFd_fw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Clientes_Contatos")]
		public ENClientes_ContatosEntityRecord ssENClientes_Contatos;


		public static implicit operator ENClientes_ContatosEntityRecord(RCClientes_ContatosRecord r) {
			return r.ssENClientes_Contatos;
		}

		public static implicit operator RCClientes_ContatosRecord(ENClientes_ContatosEntityRecord r) {
			RCClientes_ContatosRecord res = new RCClientes_ContatosRecord(null);
			res.ssENClientes_Contatos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENClientes_Contatos.ChangedAttributes = value;
			}
			get {
				return ssENClientes_Contatos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCClientes_ContatosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENClientes_Contatos = new ENClientes_ContatosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(5, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENClientes_Contatos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENClientes_Contatos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENClientes_Contatos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENClientes_Contatos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCClientes_ContatosRecord r) {
			this = r;
		}


		public static bool operator == (RCClientes_ContatosRecord a, RCClientes_ContatosRecord b) {
			if (a.ssENClientes_Contatos != b.ssENClientes_Contatos) return false;
			return true;
		}

		public static bool operator != (RCClientes_ContatosRecord a, RCClientes_ContatosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCClientes_ContatosRecord)) return false;
			return (this == (RCClientes_ContatosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENClientes_Contatos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCClientes_ContatosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENClientes_Contatos = new ENClientes_ContatosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENClientes_Contatos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENClientes_Contatos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENClientes_Contatos = (ENClientes_ContatosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENClientes_Contatos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENClientes_Contatos.InternalRecursiveSave();
		}


		public RCClientes_ContatosRecord Duplicate() {
			RCClientes_ContatosRecord t;
			t.ssENClientes_Contatos = (ENClientes_ContatosEntityRecord) this.ssENClientes_Contatos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENClientes_Contatos.ToXml(this, recordElem, "Clientes_Contatos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "clientes_contatos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Clientes_Contatos")) variable.Value = ssENClientes_Contatos; else variable.Optimized = true;
				variable.SetFieldName("clientes_contatos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENClientes_Contatos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENClientes_Contatos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdClientes_Contatos) {
				return ssENClientes_Contatos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENClientes_Contatos.FillFromOther((IRecord) other.AttributeGet(IdClientes_Contatos));
		}
		public bool IsDefault() {
			RCClientes_ContatosRecord defaultStruct = new RCClientes_ContatosRecord(null);
			if (this.ssENClientes_Contatos != defaultStruct.ssENClientes_Contatos) return false;
			return true;
		}
	} // RCClientes_ContatosRecord

	/// <summary>
	/// Structure <code>RCFornecedores_ContatosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCFornecedores_ContatosRecord: ISerializable, ITypedRecord<RCFornecedores_ContatosRecord> {
		internal static readonly GlobalObjectKey IdFornecedores_Contatos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*Fk3Bllpd69VsExuDKLRuyw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Fornecedores_Contatos")]
		public ENFornecedores_ContatosEntityRecord ssENFornecedores_Contatos;


		public static implicit operator ENFornecedores_ContatosEntityRecord(RCFornecedores_ContatosRecord r) {
			return r.ssENFornecedores_Contatos;
		}

		public static implicit operator RCFornecedores_ContatosRecord(ENFornecedores_ContatosEntityRecord r) {
			RCFornecedores_ContatosRecord res = new RCFornecedores_ContatosRecord(null);
			res.ssENFornecedores_Contatos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENFornecedores_Contatos.ChangedAttributes = value;
			}
			get {
				return ssENFornecedores_Contatos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCFornecedores_ContatosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENFornecedores_Contatos = new ENFornecedores_ContatosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(5, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENFornecedores_Contatos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENFornecedores_Contatos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENFornecedores_Contatos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENFornecedores_Contatos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCFornecedores_ContatosRecord r) {
			this = r;
		}


		public static bool operator == (RCFornecedores_ContatosRecord a, RCFornecedores_ContatosRecord b) {
			if (a.ssENFornecedores_Contatos != b.ssENFornecedores_Contatos) return false;
			return true;
		}

		public static bool operator != (RCFornecedores_ContatosRecord a, RCFornecedores_ContatosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCFornecedores_ContatosRecord)) return false;
			return (this == (RCFornecedores_ContatosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENFornecedores_Contatos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCFornecedores_ContatosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENFornecedores_Contatos = new ENFornecedores_ContatosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENFornecedores_Contatos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENFornecedores_Contatos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENFornecedores_Contatos = (ENFornecedores_ContatosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENFornecedores_Contatos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENFornecedores_Contatos.InternalRecursiveSave();
		}


		public RCFornecedores_ContatosRecord Duplicate() {
			RCFornecedores_ContatosRecord t;
			t.ssENFornecedores_Contatos = (ENFornecedores_ContatosEntityRecord) this.ssENFornecedores_Contatos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENFornecedores_Contatos.ToXml(this, recordElem, "Fornecedores_Contatos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "fornecedores_contatos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Fornecedores_Contatos")) variable.Value = ssENFornecedores_Contatos; else variable.Optimized = true;
				variable.SetFieldName("fornecedores_contatos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENFornecedores_Contatos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENFornecedores_Contatos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdFornecedores_Contatos) {
				return ssENFornecedores_Contatos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENFornecedores_Contatos.FillFromOther((IRecord) other.AttributeGet(IdFornecedores_Contatos));
		}
		public bool IsDefault() {
			RCFornecedores_ContatosRecord defaultStruct = new RCFornecedores_ContatosRecord(null);
			if (this.ssENFornecedores_Contatos != defaultStruct.ssENFornecedores_Contatos) return false;
			return true;
		}
	} // RCFornecedores_ContatosRecord

	/// <summary>
	/// Structure <code>RCObrasEtapas_GastosPrevistosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCObrasEtapas_GastosPrevistosRecord: ISerializable, ITypedRecord<RCObrasEtapas_GastosPrevistosRecord> {
		internal static readonly GlobalObjectKey IdObrasEtapas_GastosPrevistos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*akZBRXFCNmtbCnrZlva+ug");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ObrasEtapas_GastosPrevistos")]
		public ENObrasEtapas_GastosPrevistosEntityRecord ssENObrasEtapas_GastosPrevistos;


		public static implicit operator ENObrasEtapas_GastosPrevistosEntityRecord(RCObrasEtapas_GastosPrevistosRecord r) {
			return r.ssENObrasEtapas_GastosPrevistos;
		}

		public static implicit operator RCObrasEtapas_GastosPrevistosRecord(ENObrasEtapas_GastosPrevistosEntityRecord r) {
			RCObrasEtapas_GastosPrevistosRecord res = new RCObrasEtapas_GastosPrevistosRecord(null);
			res.ssENObrasEtapas_GastosPrevistos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENObrasEtapas_GastosPrevistos.ChangedAttributes = value;
			}
			get {
				return ssENObrasEtapas_GastosPrevistos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCObrasEtapas_GastosPrevistosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENObrasEtapas_GastosPrevistos = new ENObrasEtapas_GastosPrevistosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(7, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENObrasEtapas_GastosPrevistos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENObrasEtapas_GastosPrevistos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENObrasEtapas_GastosPrevistos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENObrasEtapas_GastosPrevistos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCObrasEtapas_GastosPrevistosRecord r) {
			this = r;
		}


		public static bool operator == (RCObrasEtapas_GastosPrevistosRecord a, RCObrasEtapas_GastosPrevistosRecord b) {
			if (a.ssENObrasEtapas_GastosPrevistos != b.ssENObrasEtapas_GastosPrevistos) return false;
			return true;
		}

		public static bool operator != (RCObrasEtapas_GastosPrevistosRecord a, RCObrasEtapas_GastosPrevistosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCObrasEtapas_GastosPrevistosRecord)) return false;
			return (this == (RCObrasEtapas_GastosPrevistosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENObrasEtapas_GastosPrevistos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCObrasEtapas_GastosPrevistosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENObrasEtapas_GastosPrevistos = new ENObrasEtapas_GastosPrevistosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENObrasEtapas_GastosPrevistos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENObrasEtapas_GastosPrevistos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENObrasEtapas_GastosPrevistos = (ENObrasEtapas_GastosPrevistosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENObrasEtapas_GastosPrevistos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENObrasEtapas_GastosPrevistos.InternalRecursiveSave();
		}


		public RCObrasEtapas_GastosPrevistosRecord Duplicate() {
			RCObrasEtapas_GastosPrevistosRecord t;
			t.ssENObrasEtapas_GastosPrevistos = (ENObrasEtapas_GastosPrevistosEntityRecord) this.ssENObrasEtapas_GastosPrevistos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENObrasEtapas_GastosPrevistos.ToXml(this, recordElem, "ObrasEtapas_GastosPrevistos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "obrasetapas_gastosprevistos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ObrasEtapas_GastosPrevistos")) variable.Value = ssENObrasEtapas_GastosPrevistos; else variable.Optimized = true;
				variable.SetFieldName("obrasetapas_gastosprevistos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas_GastosPrevistos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas_GastosPrevistos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdObrasEtapas_GastosPrevistos) {
				return ssENObrasEtapas_GastosPrevistos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENObrasEtapas_GastosPrevistos.FillFromOther((IRecord) other.AttributeGet(IdObrasEtapas_GastosPrevistos));
		}
		public bool IsDefault() {
			RCObrasEtapas_GastosPrevistosRecord defaultStruct = new RCObrasEtapas_GastosPrevistosRecord(null);
			if (this.ssENObrasEtapas_GastosPrevistos != defaultStruct.ssENObrasEtapas_GastosPrevistos) return false;
			return true;
		}
	} // RCObrasEtapas_GastosPrevistosRecord

	/// <summary>
	/// Structure <code>RCParametrizacoesRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCParametrizacoesRecord: ISerializable, ITypedRecord<RCParametrizacoesRecord> {
		internal static readonly GlobalObjectKey IdParametrizacoes = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*D9FH8BwpumjDmA5ZGdtICg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Parametrizacoes")]
		public ENParametrizacoesEntityRecord ssENParametrizacoes;


		public static implicit operator ENParametrizacoesEntityRecord(RCParametrizacoesRecord r) {
			return r.ssENParametrizacoes;
		}

		public static implicit operator RCParametrizacoesRecord(ENParametrizacoesEntityRecord r) {
			RCParametrizacoesRecord res = new RCParametrizacoesRecord(null);
			res.ssENParametrizacoes = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENParametrizacoes.ChangedAttributes = value;
			}
			get {
				return ssENParametrizacoes.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCParametrizacoesRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENParametrizacoes = new ENParametrizacoesEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(4, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENParametrizacoes.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENParametrizacoes.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENParametrizacoes.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENParametrizacoes.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCParametrizacoesRecord r) {
			this = r;
		}


		public static bool operator == (RCParametrizacoesRecord a, RCParametrizacoesRecord b) {
			if (a.ssENParametrizacoes != b.ssENParametrizacoes) return false;
			return true;
		}

		public static bool operator != (RCParametrizacoesRecord a, RCParametrizacoesRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCParametrizacoesRecord)) return false;
			return (this == (RCParametrizacoesRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENParametrizacoes.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCParametrizacoesRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENParametrizacoes = new ENParametrizacoesEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENParametrizacoes", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENParametrizacoes' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENParametrizacoes = (ENParametrizacoesEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENParametrizacoes.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENParametrizacoes.InternalRecursiveSave();
		}


		public RCParametrizacoesRecord Duplicate() {
			RCParametrizacoesRecord t;
			t.ssENParametrizacoes = (ENParametrizacoesEntityRecord) this.ssENParametrizacoes.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENParametrizacoes.ToXml(this, recordElem, "Parametrizacoes", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "parametrizacoes") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Parametrizacoes")) variable.Value = ssENParametrizacoes; else variable.Optimized = true;
				variable.SetFieldName("parametrizacoes");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENParametrizacoes.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENParametrizacoes.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdParametrizacoes) {
				return ssENParametrizacoes;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENParametrizacoes.FillFromOther((IRecord) other.AttributeGet(IdParametrizacoes));
		}
		public bool IsDefault() {
			RCParametrizacoesRecord defaultStruct = new RCParametrizacoesRecord(null);
			if (this.ssENParametrizacoes != defaultStruct.ssENParametrizacoes) return false;
			return true;
		}
	} // RCParametrizacoesRecord

	/// <summary>
	/// Structure <code>RCUsoVeiculosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCUsoVeiculosRecord: ISerializable, ITypedRecord<RCUsoVeiculosRecord> {
		internal static readonly GlobalObjectKey IdUsoVeiculos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*+R9KIbMNapztkRay6A51Yw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("UsoVeiculos")]
		public ENUsoVeiculosEntityRecord ssENUsoVeiculos;


		public static implicit operator ENUsoVeiculosEntityRecord(RCUsoVeiculosRecord r) {
			return r.ssENUsoVeiculos;
		}

		public static implicit operator RCUsoVeiculosRecord(ENUsoVeiculosEntityRecord r) {
			RCUsoVeiculosRecord res = new RCUsoVeiculosRecord(null);
			res.ssENUsoVeiculos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENUsoVeiculos.ChangedAttributes = value;
			}
			get {
				return ssENUsoVeiculos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCUsoVeiculosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENUsoVeiculos = new ENUsoVeiculosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(7, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENUsoVeiculos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENUsoVeiculos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENUsoVeiculos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENUsoVeiculos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCUsoVeiculosRecord r) {
			this = r;
		}


		public static bool operator == (RCUsoVeiculosRecord a, RCUsoVeiculosRecord b) {
			if (a.ssENUsoVeiculos != b.ssENUsoVeiculos) return false;
			return true;
		}

		public static bool operator != (RCUsoVeiculosRecord a, RCUsoVeiculosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCUsoVeiculosRecord)) return false;
			return (this == (RCUsoVeiculosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENUsoVeiculos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCUsoVeiculosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENUsoVeiculos = new ENUsoVeiculosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENUsoVeiculos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENUsoVeiculos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENUsoVeiculos = (ENUsoVeiculosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENUsoVeiculos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENUsoVeiculos.InternalRecursiveSave();
		}


		public RCUsoVeiculosRecord Duplicate() {
			RCUsoVeiculosRecord t;
			t.ssENUsoVeiculos = (ENUsoVeiculosEntityRecord) this.ssENUsoVeiculos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENUsoVeiculos.ToXml(this, recordElem, "UsoVeiculos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "usoveiculos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".UsoVeiculos")) variable.Value = ssENUsoVeiculos; else variable.Optimized = true;
				variable.SetFieldName("usoveiculos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENUsoVeiculos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENUsoVeiculos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdUsoVeiculos) {
				return ssENUsoVeiculos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENUsoVeiculos.FillFromOther((IRecord) other.AttributeGet(IdUsoVeiculos));
		}
		public bool IsDefault() {
			RCUsoVeiculosRecord defaultStruct = new RCUsoVeiculosRecord(null);
			if (this.ssENUsoVeiculos != defaultStruct.ssENUsoVeiculos) return false;
			return true;
		}
	} // RCUsoVeiculosRecord

	/// <summary>
	/// Structure <code>RCNotasFiscaisPrazoRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCNotasFiscaisPrazoRecord: ISerializable, ITypedRecord<RCNotasFiscaisPrazoRecord> {
		internal static readonly GlobalObjectKey IdNotasFiscaisPrazo = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*j99eNd3g2OksjenTkuZXsw");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("NotasFiscaisPrazo")]
		public ENNotasFiscaisPrazoEntityRecord ssENNotasFiscaisPrazo;


		public static implicit operator ENNotasFiscaisPrazoEntityRecord(RCNotasFiscaisPrazoRecord r) {
			return r.ssENNotasFiscaisPrazo;
		}

		public static implicit operator RCNotasFiscaisPrazoRecord(ENNotasFiscaisPrazoEntityRecord r) {
			RCNotasFiscaisPrazoRecord res = new RCNotasFiscaisPrazoRecord(null);
			res.ssENNotasFiscaisPrazo = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENNotasFiscaisPrazo.ChangedAttributes = value;
			}
			get {
				return ssENNotasFiscaisPrazo.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCNotasFiscaisPrazoRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENNotasFiscaisPrazo = new ENNotasFiscaisPrazoEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(2, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENNotasFiscaisPrazo.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENNotasFiscaisPrazo.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENNotasFiscaisPrazo.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENNotasFiscaisPrazo.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCNotasFiscaisPrazoRecord r) {
			this = r;
		}


		public static bool operator == (RCNotasFiscaisPrazoRecord a, RCNotasFiscaisPrazoRecord b) {
			if (a.ssENNotasFiscaisPrazo != b.ssENNotasFiscaisPrazo) return false;
			return true;
		}

		public static bool operator != (RCNotasFiscaisPrazoRecord a, RCNotasFiscaisPrazoRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCNotasFiscaisPrazoRecord)) return false;
			return (this == (RCNotasFiscaisPrazoRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENNotasFiscaisPrazo.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCNotasFiscaisPrazoRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENNotasFiscaisPrazo = new ENNotasFiscaisPrazoEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENNotasFiscaisPrazo", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENNotasFiscaisPrazo' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENNotasFiscaisPrazo = (ENNotasFiscaisPrazoEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENNotasFiscaisPrazo.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENNotasFiscaisPrazo.InternalRecursiveSave();
		}


		public RCNotasFiscaisPrazoRecord Duplicate() {
			RCNotasFiscaisPrazoRecord t;
			t.ssENNotasFiscaisPrazo = (ENNotasFiscaisPrazoEntityRecord) this.ssENNotasFiscaisPrazo.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENNotasFiscaisPrazo.ToXml(this, recordElem, "NotasFiscaisPrazo", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "notasfiscaisprazo") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".NotasFiscaisPrazo")) variable.Value = ssENNotasFiscaisPrazo; else variable.Optimized = true;
				variable.SetFieldName("notasfiscaisprazo");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENNotasFiscaisPrazo.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENNotasFiscaisPrazo.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdNotasFiscaisPrazo) {
				return ssENNotasFiscaisPrazo;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENNotasFiscaisPrazo.FillFromOther((IRecord) other.AttributeGet(IdNotasFiscaisPrazo));
		}
		public bool IsDefault() {
			RCNotasFiscaisPrazoRecord defaultStruct = new RCNotasFiscaisPrazoRecord(null);
			if (this.ssENNotasFiscaisPrazo != defaultStruct.ssENNotasFiscaisPrazo) return false;
			return true;
		}
	} // RCNotasFiscaisPrazoRecord

	/// <summary>
	/// Structure <code>RCEmpilhadeiras_UsosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCEmpilhadeiras_UsosRecord: ISerializable, ITypedRecord<RCEmpilhadeiras_UsosRecord> {
		internal static readonly GlobalObjectKey IdEmpilhadeiras_Usos = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*pFTVA92ZqwABWRzqu6Ro7Q");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Empilhadeiras_Usos")]
		public ENEmpilhadeiras_UsosEntityRecord ssENEmpilhadeiras_Usos;


		public static implicit operator ENEmpilhadeiras_UsosEntityRecord(RCEmpilhadeiras_UsosRecord r) {
			return r.ssENEmpilhadeiras_Usos;
		}

		public static implicit operator RCEmpilhadeiras_UsosRecord(ENEmpilhadeiras_UsosEntityRecord r) {
			RCEmpilhadeiras_UsosRecord res = new RCEmpilhadeiras_UsosRecord(null);
			res.ssENEmpilhadeiras_Usos = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENEmpilhadeiras_Usos.ChangedAttributes = value;
			}
			get {
				return ssENEmpilhadeiras_Usos.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCEmpilhadeiras_UsosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENEmpilhadeiras_Usos = new ENEmpilhadeiras_UsosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(6, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENEmpilhadeiras_Usos.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENEmpilhadeiras_Usos.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENEmpilhadeiras_Usos.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENEmpilhadeiras_Usos.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCEmpilhadeiras_UsosRecord r) {
			this = r;
		}


		public static bool operator == (RCEmpilhadeiras_UsosRecord a, RCEmpilhadeiras_UsosRecord b) {
			if (a.ssENEmpilhadeiras_Usos != b.ssENEmpilhadeiras_Usos) return false;
			return true;
		}

		public static bool operator != (RCEmpilhadeiras_UsosRecord a, RCEmpilhadeiras_UsosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCEmpilhadeiras_UsosRecord)) return false;
			return (this == (RCEmpilhadeiras_UsosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENEmpilhadeiras_Usos.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCEmpilhadeiras_UsosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENEmpilhadeiras_Usos = new ENEmpilhadeiras_UsosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENEmpilhadeiras_Usos", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENEmpilhadeiras_Usos' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENEmpilhadeiras_Usos = (ENEmpilhadeiras_UsosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENEmpilhadeiras_Usos.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENEmpilhadeiras_Usos.InternalRecursiveSave();
		}


		public RCEmpilhadeiras_UsosRecord Duplicate() {
			RCEmpilhadeiras_UsosRecord t;
			t.ssENEmpilhadeiras_Usos = (ENEmpilhadeiras_UsosEntityRecord) this.ssENEmpilhadeiras_Usos.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENEmpilhadeiras_Usos.ToXml(this, recordElem, "Empilhadeiras_Usos", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "empilhadeiras_usos") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Empilhadeiras_Usos")) variable.Value = ssENEmpilhadeiras_Usos; else variable.Optimized = true;
				variable.SetFieldName("empilhadeiras_usos");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENEmpilhadeiras_Usos.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENEmpilhadeiras_Usos.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdEmpilhadeiras_Usos) {
				return ssENEmpilhadeiras_Usos;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENEmpilhadeiras_Usos.FillFromOther((IRecord) other.AttributeGet(IdEmpilhadeiras_Usos));
		}
		public bool IsDefault() {
			RCEmpilhadeiras_UsosRecord defaultStruct = new RCEmpilhadeiras_UsosRecord(null);
			if (this.ssENEmpilhadeiras_Usos != defaultStruct.ssENEmpilhadeiras_Usos) return false;
			return true;
		}
	} // RCEmpilhadeiras_UsosRecord

	/// <summary>
	/// Structure <code>RCObrasEtapas_FollowUpRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCObrasEtapas_FollowUpRecord: ISerializable, ITypedRecord<RCObrasEtapas_FollowUpRecord> {
		internal static readonly GlobalObjectKey IdObrasEtapas_FollowUp = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*6Y_GoeAGxzUIudKVm_vQSQ");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("ObrasEtapas_FollowUp")]
		public ENObrasEtapas_FollowUpEntityRecord ssENObrasEtapas_FollowUp;


		public static implicit operator ENObrasEtapas_FollowUpEntityRecord(RCObrasEtapas_FollowUpRecord r) {
			return r.ssENObrasEtapas_FollowUp;
		}

		public static implicit operator RCObrasEtapas_FollowUpRecord(ENObrasEtapas_FollowUpEntityRecord r) {
			RCObrasEtapas_FollowUpRecord res = new RCObrasEtapas_FollowUpRecord(null);
			res.ssENObrasEtapas_FollowUp = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENObrasEtapas_FollowUp.ChangedAttributes = value;
			}
			get {
				return ssENObrasEtapas_FollowUp.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCObrasEtapas_FollowUpRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENObrasEtapas_FollowUp = new ENObrasEtapas_FollowUpEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(6, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENObrasEtapas_FollowUp.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENObrasEtapas_FollowUp.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENObrasEtapas_FollowUp.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENObrasEtapas_FollowUp.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCObrasEtapas_FollowUpRecord r) {
			this = r;
		}


		public static bool operator == (RCObrasEtapas_FollowUpRecord a, RCObrasEtapas_FollowUpRecord b) {
			if (a.ssENObrasEtapas_FollowUp != b.ssENObrasEtapas_FollowUp) return false;
			return true;
		}

		public static bool operator != (RCObrasEtapas_FollowUpRecord a, RCObrasEtapas_FollowUpRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCObrasEtapas_FollowUpRecord)) return false;
			return (this == (RCObrasEtapas_FollowUpRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENObrasEtapas_FollowUp.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCObrasEtapas_FollowUpRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENObrasEtapas_FollowUp = new ENObrasEtapas_FollowUpEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENObrasEtapas_FollowUp", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENObrasEtapas_FollowUp' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENObrasEtapas_FollowUp = (ENObrasEtapas_FollowUpEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENObrasEtapas_FollowUp.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENObrasEtapas_FollowUp.InternalRecursiveSave();
		}


		public RCObrasEtapas_FollowUpRecord Duplicate() {
			RCObrasEtapas_FollowUpRecord t;
			t.ssENObrasEtapas_FollowUp = (ENObrasEtapas_FollowUpEntityRecord) this.ssENObrasEtapas_FollowUp.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENObrasEtapas_FollowUp.ToXml(this, recordElem, "ObrasEtapas_FollowUp", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "obrasetapas_followup") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".ObrasEtapas_FollowUp")) variable.Value = ssENObrasEtapas_FollowUp; else variable.Optimized = true;
				variable.SetFieldName("obrasetapas_followup");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas_FollowUp.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENObrasEtapas_FollowUp.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdObrasEtapas_FollowUp) {
				return ssENObrasEtapas_FollowUp;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENObrasEtapas_FollowUp.FillFromOther((IRecord) other.AttributeGet(IdObrasEtapas_FollowUp));
		}
		public bool IsDefault() {
			RCObrasEtapas_FollowUpRecord defaultStruct = new RCObrasEtapas_FollowUpRecord(null);
			if (this.ssENObrasEtapas_FollowUp != defaultStruct.ssENObrasEtapas_FollowUp) return false;
			return true;
		}
	} // RCObrasEtapas_FollowUpRecord

	/// <summary>
	/// Structure <code>RCUsuariosRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCUsuariosRecord: ISerializable, ITypedRecord<RCUsuariosRecord> {
		internal static readonly GlobalObjectKey IdUsuarios = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*5WLYtArpq4lcavoDo7PnJg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("Usuarios")]
		public ENUsuariosEntityRecord ssENUsuarios;


		public static implicit operator ENUsuariosEntityRecord(RCUsuariosRecord r) {
			return r.ssENUsuarios;
		}

		public static implicit operator RCUsuariosRecord(ENUsuariosEntityRecord r) {
			RCUsuariosRecord res = new RCUsuariosRecord(null);
			res.ssENUsuarios = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENUsuarios.ChangedAttributes = value;
			}
			get {
				return ssENUsuarios.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCUsuariosRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENUsuarios = new ENUsuariosEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(8, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENUsuarios.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENUsuarios.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENUsuarios.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENUsuarios.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCUsuariosRecord r) {
			this = r;
		}


		public static bool operator == (RCUsuariosRecord a, RCUsuariosRecord b) {
			if (a.ssENUsuarios != b.ssENUsuarios) return false;
			return true;
		}

		public static bool operator != (RCUsuariosRecord a, RCUsuariosRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCUsuariosRecord)) return false;
			return (this == (RCUsuariosRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENUsuarios.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCUsuariosRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENUsuarios = new ENUsuariosEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENUsuarios", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENUsuarios' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENUsuarios = (ENUsuariosEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENUsuarios.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENUsuarios.InternalRecursiveSave();
		}


		public RCUsuariosRecord Duplicate() {
			RCUsuariosRecord t;
			t.ssENUsuarios = (ENUsuariosEntityRecord) this.ssENUsuarios.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENUsuarios.ToXml(this, recordElem, "Usuarios", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "usuarios") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".Usuarios")) variable.Value = ssENUsuarios; else variable.Optimized = true;
				variable.SetFieldName("usuarios");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENUsuarios.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENUsuarios.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdUsuarios) {
				return ssENUsuarios;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENUsuarios.FillFromOther((IRecord) other.AttributeGet(IdUsuarios));
		}
		public bool IsDefault() {
			RCUsuariosRecord defaultStruct = new RCUsuariosRecord(null);
			if (this.ssENUsuarios != defaultStruct.ssENUsuarios) return false;
			return true;
		}
	} // RCUsuariosRecord

	/// <summary>
	/// Structure <code>RCOrdemPagamentoRecord</code>
	/// </summary>
	[Serializable()]
	public partial struct RCOrdemPagamentoRecord: ISerializable, ITypedRecord<RCOrdemPagamentoRecord> {
		internal static readonly GlobalObjectKey IdOrdemPagamento = GlobalObjectKey.Parse("2UmDmepsh0WSfJ_D1JexCA*kqRRGNIQxqj_ny3V56AAXg");

		public static void EnsureInitialized() {}
		[System.Xml.Serialization.XmlElement("OrdemPagamento")]
		public ENOrdemPagamentoEntityRecord ssENOrdemPagamento;


		public static implicit operator ENOrdemPagamentoEntityRecord(RCOrdemPagamentoRecord r) {
			return r.ssENOrdemPagamento;
		}

		public static implicit operator RCOrdemPagamentoRecord(ENOrdemPagamentoEntityRecord r) {
			RCOrdemPagamentoRecord res = new RCOrdemPagamentoRecord(null);
			res.ssENOrdemPagamento = r;
			return res;
		}

		public BitArray ChangedAttributes {
			set {
				ssENOrdemPagamento.ChangedAttributes = value;
			}
			get {
				return ssENOrdemPagamento.ChangedAttributes;
			}
		}
		public BitArray OptimizedAttributes;

		public RCOrdemPagamentoRecord(params string[] dummy) {
			OptimizedAttributes = null;
			ssENOrdemPagamento = new ENOrdemPagamentoEntityRecord(null);
		}

		public BitArray[] GetDefaultOptimizedValues() {
			BitArray[] all = new BitArray[1];
			all[0] = new BitArray(16, false);
			return all;
		}

		public BitArray[] AllOptimizedAttributes {
			set {
				if (value == null) {
					ssENOrdemPagamento.OptimizedAttributes = GetDefaultOptimizedValues()[0];
				} else {
					ssENOrdemPagamento.OptimizedAttributes = value[0];
				}
			}
			get {
				BitArray[] all = new BitArray[1];
				all[0] = ssENOrdemPagamento.OptimizedAttributes;
				return all;
			}
		}

		/// <summary>
		/// Read a record from database
		/// </summary>
		/// <param name="r"> Data base reader</param>
		/// <param name="index"> index</param>
		public void Read(IDataReader r, ref int index) {
			ssENOrdemPagamento.Read(r, ref index);
		}
		/// <summary>
		/// Read from database
		/// </summary>
		/// <param name="r"> Data reader</param>
		public void ReadDB(IDataReader r) {
			int index = 0;
			Read(r, ref index);
		}

		/// <summary>
		/// Read from record
		/// </summary>
		/// <param name="r"> Record</param>
		public void ReadIM(RCOrdemPagamentoRecord r) {
			this = r;
		}


		public static bool operator == (RCOrdemPagamentoRecord a, RCOrdemPagamentoRecord b) {
			if (a.ssENOrdemPagamento != b.ssENOrdemPagamento) return false;
			return true;
		}

		public static bool operator != (RCOrdemPagamentoRecord a, RCOrdemPagamentoRecord b) {
			return !(a==b);
		}

		public override bool Equals(object o) {
			if (o.GetType() != typeof(RCOrdemPagamentoRecord)) return false;
			return (this == (RCOrdemPagamentoRecord) o);
		}

		public override int GetHashCode() {
			try {
				return base.GetHashCode()
				^ ssENOrdemPagamento.GetHashCode()
				;
			} catch {
				return base.GetHashCode();
			}
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			Type objInfo = this.GetType();
			FieldInfo[] fields;
			fields = objInfo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			for (int i = 0; i < fields.Length; i++)
			if (fields[i] .FieldType.IsSerializable)
			info.AddValue(fields[i] .Name, fields[i] .GetValue(this));
		}

		public RCOrdemPagamentoRecord(SerializationInfo info, StreamingContext context) {
			OptimizedAttributes = null;
			ssENOrdemPagamento = new ENOrdemPagamentoEntityRecord(null);
			Type objInfo = this.GetType();
			FieldInfo fieldInfo = null;
			fieldInfo = objInfo.GetField("ssENOrdemPagamento", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			if (fieldInfo == null) {
				throw new Exception("The field named 'ssENOrdemPagamento' was not found.");
			}
			if (fieldInfo.FieldType.IsSerializable) {
				ssENOrdemPagamento = (ENOrdemPagamentoEntityRecord) info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
			}
		}

		public void RecursiveReset() {
			ssENOrdemPagamento.RecursiveReset();
		}

		public void InternalRecursiveSave() {
			ssENOrdemPagamento.InternalRecursiveSave();
		}


		public RCOrdemPagamentoRecord Duplicate() {
			RCOrdemPagamentoRecord t;
			t.ssENOrdemPagamento = (ENOrdemPagamentoEntityRecord) this.ssENOrdemPagamento.Duplicate();
			t.OptimizedAttributes = null;
			return t;
		}

		IRecord IRecord.Duplicate() {
			return Duplicate();
		}

		public void ToXml(Object parent, System.Xml.XmlElement baseElem, String fieldName, int detailLevel) {
			System.Xml.XmlElement recordElem = VarValue.AppendChild(baseElem, "Record");
			if (fieldName != null) {
				VarValue.AppendAttribute(recordElem, "debug.field", fieldName);
			}
			if (detailLevel > 0) {
				ssENOrdemPagamento.ToXml(this, recordElem, "OrdemPagamento", detailLevel - 1);
			} else {
				VarValue.AppendDeferredEvaluationElement(recordElem);
			}
		}

		public void EvaluateFields(VarValue variable, Object parent, String baseName, String fields) {
			String head = VarValue.GetHead(fields);
			String tail = VarValue.GetTail(fields);
			variable.Found = false;
			if (head == "ordempagamento") {
				if (!VarValue.FieldIsOptimized(parent, baseName + ".OrdemPagamento")) variable.Value = ssENOrdemPagamento; else variable.Optimized = true;
				variable.SetFieldName("ordempagamento");
			}
			if (variable.Found && tail != null) variable.EvaluateFields(this, head, tail);
		}

		public bool ChangedAttributeGet(GlobalObjectKey key) {
			return ssENOrdemPagamento.ChangedAttributeGet(key);
		}

		public bool OptimizedAttributeGet(GlobalObjectKey key) {
			return ssENOrdemPagamento.OptimizedAttributeGet(key);
		}

		public object AttributeGet(GlobalObjectKey key) {
			if (key == IdOrdemPagamento) {
				return ssENOrdemPagamento;
			} else {
				throw new Exception("Invalid key");
			}
		}
		public void FillFromOther(IRecord other) {
			if (other == null) return;
			ssENOrdemPagamento.FillFromOther((IRecord) other.AttributeGet(IdOrdemPagamento));
		}
		public bool IsDefault() {
			RCOrdemPagamentoRecord defaultStruct = new RCOrdemPagamentoRecord(null);
			if (this.ssENOrdemPagamento != defaultStruct.ssENOrdemPagamento) return false;
			return true;
		}
	} // RCOrdemPagamentoRecord
}
