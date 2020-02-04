
# iri.plugin

universal plugin engine for .net

# concepts

## container

containers are based around the idea of providing an interface and then one or more objects implementing that interface.
at runtime, the registered objects can be retrieved and used as plugins because they all expose the same interface to the plugin host.
the `CookieJar` container provides various variants of `Register` and `Resolve` operations.

## plugin

a "plugin" defines a unit of pluggable functionality. it exposes metadata to make it recognizable and dynamically loadable at runtime. at its most basic, it implements a `BeforeActivation: CookieJar -> void` method that is intended to allow it to register any relevant types into a provided container.

## plugin loader

plugin loaders are created with an associated plugin type that they know how to load. they can be used to load plugins from individual classes or from a whole assembly. the plugin loader is completely independent of the container, its focus is simply loading a plugin type which is able to handle the container.
