// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package org.drools.agent;

@net.sf.jni4net.attributes.ClrTypeInfo
public final class KnowledgeAgentConfiguration_ {
    
    //<generated-static>
    private static system.Type staticType;
    
    public static system.Type typeof() {
        return org.drools.agent.KnowledgeAgentConfiguration_.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        org.drools.agent.KnowledgeAgentConfiguration_.staticType = staticType;
    }
    //</generated-static>
}

//<generated-proxy>
@net.sf.jni4net.attributes.ClrProxy
class __KnowledgeAgentConfiguration extends system.Object implements org.drools.agent.KnowledgeAgentConfiguration {
    
    protected __KnowledgeAgentConfiguration(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("(Ljava/lang/String;Ljava/lang/String;)V")
    public native void setProperty(java.lang.String par0, java.lang.String par1);
    
    @net.sf.jni4net.attributes.ClrMethod("(Ljava/lang/String;)Ljava/lang/String;")
    public native java.lang.String getProperty(java.lang.String par0);
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native boolean isScanResources();
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native boolean isScanDirectories();
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native boolean isMonitorChangeSetEvents();
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native boolean isNewInstance();
    
    @net.sf.jni4net.attributes.ClrMethod("()Z")
    public native boolean isUseKBaseClassLoaderForCompiling();
}
//</generated-proxy>