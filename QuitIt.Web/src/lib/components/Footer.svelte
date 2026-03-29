<script>
	import { resolve } from "$app/paths";
	import homeIconSrc from "$lib/assets/home-outline.svg";
	import triggerIconSrc from "$lib/assets/vulnerability-svgrepo-com.svg";
	import dashboardIconSrc from "$lib/assets/knowledge-graph-dashboard-svgrepo-com.svg";
	import AddButton from "./home/AddButton.svelte";
	import AddCigaretteModal from "./home/AddCigaretteModal.svelte";

	import { page } from "$app/stores";

	let currentPageName = $derived($page.url.pathname.split("/").filter(Boolean).pop() || "Home");

	let modal = $state(null);

	function openModal() {
		modal.open();
	}
</script>

<footer class="footer">
	<a href={resolve("/triggers")} class="logo-container nav-btn">
		<img class="page-logo" src={triggerIconSrc} alt="" />
		<p>Triggers</p>
	</a>

	<a href={resolve("/")} class="logo-container nav-btn">
		<img class="page-logo" src={homeIconSrc} alt="" />
		<p>Home</p>
	</a>

	<a href={resolve("/dashboard")} class="logo-container nav-btn">
		<img class="page-logo" src={dashboardIconSrc} alt="" />
		<p>Dashboard</p>
	</a>

	{#if currentPageName == "Home"}
		<AddButton onOpen={openModal} />
		<AddCigaretteModal bind:this={modal} />
	{/if}
</footer>

<style>
	a,
	a:visited {
		color: white;
		text-decoration: none;
	}

	a:active {
		color: #1fee14;
		outline-offset: 1rem;
	}

	@media (hover: hover) {
		a:hover {
			color: #1fee14;
		}
	}
</style>
