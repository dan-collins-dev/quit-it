<script>
	import favicon from "$lib/assets/favicon.svg";
	import Header from "$lib/components/Header.svelte";
	import Footer from "$lib/components/Footer.svelte";
	import "../app.css";
	// import AddCigaretteModal from "$lib/components/AddCigaretteModal.svelte";
	let { children } = $props();
</script>

<svelte:head>
	<link rel="icon" href={favicon} />
</svelte:head>

<Header />

<main class="main">
	{@render children()}
</main>


<Footer />
