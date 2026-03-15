<script>
	import { resolve } from "$app/paths";
	import homeIconSrc from "$lib/assets/home-outline.svg";
	import addIconSrc from "$lib/assets/add-circle-outline.svg";
	import triggerIconSrc from "$lib/assets/vulnerability-svgrepo-com.svg";
</script>

<footer class="footer">
	<a href={resolve("/triggers")} class="logo-container nav-btn">
		<img class="logo" src={triggerIconSrc} alt="" />
	</a>

	<a href={resolve("/")} class="logo-container nav-btn">
		<img class="logo" src={homeIconSrc} alt="" />
	</a>

	<a href={resolve("/dashboard")} id="add-btn" class="logo-container nav-btn">
		<img class="logo" src={addIconSrc} alt="" />
	</a>
</footer>
